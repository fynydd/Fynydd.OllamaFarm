using System.Net.Sockets;
using Fynydd.OllamaFarm.Models;

namespace Fynydd.OllamaFarm.Services;

public sealed class StateService
{
    #region Properties
    
    public int Port { get; set; } = 4444;
    public int DelayMs { get; set; }
    public static int RetrySeconds => 30;
    public ConcurrentBag<OllamaHost> Hosts { get; set; } = [];
    
    #endregion
    
    #region Methods
    
    public static async Task ServerAvailableAsync(OllamaHost host)
    {
        try
        {
            host.NextPing = DateTime.Now.AddSeconds(RetrySeconds);
            
            using var tcpClient = new TcpClient();

            var cancellationTokenSource = new CancellationTokenSource(OllamaHost.ConnectTimeoutSeconds);

            await tcpClient.ConnectAsync(host.Address, host.Port, cancellationTokenSource.Token);

            host.IsOnline = true;
            host.NextPing = DateTime.Now.AddSeconds(RetrySeconds);

            return;
        }
        catch
        {
            // ignored
        }

        host.IsOnline = false;
        host.NextPing = DateTime.Now.AddSeconds(RetrySeconds);
    }
    
    #endregion
}