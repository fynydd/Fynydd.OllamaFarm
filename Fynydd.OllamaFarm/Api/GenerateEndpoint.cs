using System.Net;
using System.Text.Json;
using Fynydd.OllamaFarm.Models;
using Fynydd.OllamaFarm.Services;

namespace Fynydd.OllamaFarm.Api;

public static class GenerateEndpoint
{
    public static void AddGenerateEndpoint(this WebApplication app)
    {
        app.MapPost("/api/generate/", async Task<IResult> (HttpRequest request, HttpResponse response, StateService stateService, HttpClient httpClient) =>
            {
                var jsonRequest = string.Empty;

                using (var reader = new StreamReader(request.Body))
                {
                    jsonRequest = await reader.ReadToEndAsync();
                }

                if (string.IsNullOrEmpty(jsonRequest))
                {
                    return Results.BadRequest(new
                    {
                        Message = "No JSON payload"
                    });
                }

                var farmModel = JsonSerializer.Deserialize<FarmSubmodel>(jsonRequest);
                var requestedHost = farmModel?.farm_host ?? string.Empty;

                if (requestedHost.Length > 0)
                {
                    if (requestedHost.Contains(':') == false)
                        requestedHost = $"{requestedHost}:11434";
                }
                
                OllamaHost? host = null;

                foreach (var _host in stateService.Hosts)
                {
                    if (_host.IsBusy || (_host.IsOffline && _host.NextPing > DateTime.Now))
                        continue;

                    _host.IsBusy = true;

                    var wasOnline = _host.IsOnline;
                    var wasOffline = _host.IsOnline == false;
                    
                    if (_host.NextPing <= DateTime.Now)
                        await StateService.ServerAvailableAsync(_host);
                    
                    if (_host.IsOffline && wasOnline)
                    {
                        _host.IsBusy = false;
                        ConsoleHelper.WriteLine($"{DateTime.Now:s} => Ollama host {_host.Address}:{_host.Port} offline; retry in {StateService.RetrySeconds} secs");
                    }

                    if (_host.IsOnline && wasOffline)
                    {
                        _host.IsBusy = false;
                        ConsoleHelper.WriteLine($"{DateTime.Now:s} => Ollama host {_host.Address}:{_host.Port} back online");
                    }

                    if (_host.IsOnline && host is null && (string.IsNullOrEmpty(requestedHost) || requestedHost.Equals(_host.FullAddress, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        host = _host;
                    }
                    else
                    {
                        _host.IsBusy = false;
                    }
                }

                if (host is null)
                {
                    if (string.IsNullOrEmpty(requestedHost))
                        return Results.Json(new
                        {
                            Message = "All Ollama hosts are busy"
                        
                        }, JsonSerializerOptions.Default, "application/json", (int)HttpStatusCode.TooManyRequests);
                    
                    var _host = stateService.Hosts.FirstOrDefault(h => h.FullAddress.Equals(requestedHost, StringComparison.InvariantCultureIgnoreCase));

                    if (_host is null)
                        return Results.BadRequest(new
                        {
                            Message = $"Requested host {requestedHost} does not exist"
                        });

                    return Results.Json(new
                    {
                        Message = $"Requested host {requestedHost} is {(_host.IsOffline ? "offline" : "busy")}"
                    
                    }, JsonSerializerOptions.Default, "application/json", (int)HttpStatusCode.TooManyRequests);
                }

                var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(OllamaHost.RequestTimeoutSeconds));
                
                try
                {
                    var timer = new Stopwatch();
                    var requestId = jsonRequest.Crc32();
                    
                    timer.Start();
                    
                    ConsoleHelper.WriteLine($"{DateTime.Now:s} => Request to {host.Address}:{host.Port} (#{requestId})");
                    
                    var completion = farmModel?.stream ?? false
                        ? HttpCompletionOption.ResponseHeadersRead
                        : HttpCompletionOption.ResponseContentRead;                

                    var httpResponse = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Post, $"http://{host.Address}:{host.Port}/api/generate/")
                    {
                        Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
                        
                    }, completion, cancellationTokenSource.Token);

                    if (farmModel?.stream ?? false)
                    {
                        response.ContentType = "application/json";

                        await using (var stream = await httpResponse.Content.ReadAsStreamAsync(cancellationTokenSource.Token))
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                while (reader.EndOfStream == false && cancellationTokenSource.IsCancellationRequested == false)
                                {
                                    var line = await reader.ReadLineAsync(cancellationTokenSource.Token) + '\n';

                                    if (string.IsNullOrEmpty(line))
                                        continue;
                                    
                                    line = line.TrimStart('{');
                                    line = $"{{\"farm_host\":\"{host.Address}:{host.Port}\"," + line;

                                    await response.Body.WriteAsync(Encoding.UTF8.GetBytes(line), cancellationTokenSource.Token);
                                    await response.Body.FlushAsync(cancellationTokenSource.Token);
                                }
                            }
                        }

                        timer.Stop();

                        if (stateService.DelayMs > 0)
                            await Task.Delay(stateService.DelayMs, cancellationTokenSource.Token);
                        
                        ConsoleHelper.WriteLine($"{DateTime.Now:s} => Request to {host.Address}:{host.Port} (#{requestId}) streamed in {(double)timer.ElapsedMilliseconds / 1000:F2}s{(stateService.DelayMs > 0 ? $" ({stateService.DelayMs}ms delay)" : string.Empty)}");

                        return Results.Empty;
                    }
                    else
                    {
                        var responseJson = await httpResponse.Content.ReadAsStringAsync(cancellationTokenSource.Token);

                        responseJson = responseJson.TrimStart().TrimStart('{');
                        responseJson = $"{{\"farm_host\":\"{host.Address}:{host.Port}\"," + responseJson;
                        
                        var jsonObject = JsonSerializer.Deserialize<object>(responseJson);

                        timer.Stop();

                        if (stateService.DelayMs > 0)
                            await Task.Delay(stateService.DelayMs, cancellationTokenSource.Token);
                        
                        ConsoleHelper.WriteLine($"{DateTime.Now:s} => Request to {host.Address}:{host.Port} (#{requestId}) complete in {(double)timer.ElapsedMilliseconds / 1000:F2}s{(stateService.DelayMs > 0 ? $" ({stateService.DelayMs}ms delay)" : string.Empty)}");

                        return Results.Json(jsonObject, JsonSerializerOptions.Default, "application/json", (int)httpResponse.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    if (cancellationTokenSource.IsCancellationRequested)
                    {
                        return Results.Json(new
                        {
                            Message = $"The Ollama host request timeout of {OllamaHost.RequestTimeoutSeconds} secs has expired."
                        
                        }, JsonSerializerOptions.Default, "application/json", (int)HttpStatusCode.RequestTimeout);
                    }
                    
                    await StateService.ServerAvailableAsync(host);

                    if (host.IsOffline)
                        ConsoleHelper.WriteLine($"{DateTime.Now:s} => Ollama host {host.Address}:{host.Port} offline; retry in {StateService.RetrySeconds} secs");
                    
                    return Results.Json(new
                    {
                        Message = $"{(host.IsOffline ? $"Ollama host {host.Address}:{host.Port} offline; retry in {StateService.RetrySeconds} secs => " : string.Empty)}{e.Message}"
                        
                    }, JsonSerializerOptions.Default, "application/json", (int)HttpStatusCode.InternalServerError);
                }
                finally
                {
                    host.IsBusy = false;
                }
            });
    }
}