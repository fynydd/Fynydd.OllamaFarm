using Fynydd.OllamaFarm;
using Fynydd.OllamaFarm.Api;
using Fynydd.OllamaFarm.Services;

#region Locals

var _stateService = new StateService();

#endregion

#region Process Arguments

#if DEBUG

args = ["--delay", "10", "localhost/2", "10.0.10.3/2", "10.0.10.4"];

#endif

_stateService.Port = args.GetListenPort();
_stateService.Hosts = args.GetHosts();
_stateService.DelayMs = args.GetDelayMs();

#endregion

#region Initial Output

ConsoleHelper.RenderIntro();

if (_stateService.Hosts.IsEmpty)
{
    ConsoleHelper.RenderHelp();    
    Environment.Exit(0);
}

foreach (var host in _stateService.Hosts)
{
    await StateService.ServerAvailableAsync(host);
    
    ConsoleHelper.WriteLine($"Using Ollama host {host.Address}:{host.Port}/{host.MaxConcurrentRequests} ({(host.IsOnline ? "Online" : "Offline")})");

    if (host.IsOffline)
        host.NextPing = DateTime.Now;
}

ConsoleHelper.WriteLine($"Listening on port {_stateService.Port}; press ESC or Control+C to exit");
ConsoleHelper.WriteLine();

#endregion

#region Scaffolding

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Warning);

builder.Services.AddSingleton(_stateService);
builder.Services.AddHttpClient();

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(_stateService.Port);
});

var app = builder.Build();

#endregion

#region Endpoints

app.AddGenerateEndpoint();

#endregion

#region Handle Exit Keys

var cts = new CancellationTokenSource();

app.AddCancelKeysWatcher(cts);

#endregion

await app.RunAsync(cts.Token);
