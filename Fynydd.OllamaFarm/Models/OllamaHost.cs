namespace Fynydd.OllamaFarm.Models;

public sealed class OllamaHost
{
    public int Index { get; set; }
    public string Address { get; set; } = string.Empty;
    public int Port { get; set; } = 11434;
    public string FullHostAddress => $"{Address}:{Port}";
    public string FullWebAddress => $"{Protocol}{Address}:{Port}";
    public string Protocol { get; set; } = "http://";

    public static int ConnectTimeoutSeconds => 30;
    public static int RequestTimeoutSeconds => 900;

    public DateTime NextPing { get; set; } = DateTime.Now;
    public int MaxConcurrentRequests { get; set; } = 1;
    public int ActiveRequestsCount { get; set; }
    public long TotalRequestsCount { get; set; }
    public bool IsOnline { get; set; }
    public bool IsOffline => IsOnline == false;
    public bool HasAvailability => ActiveRequestsCount < MaxConcurrentRequests;
    public bool IsTooBusy => ActiveRequestsCount >= MaxConcurrentRequests;
}