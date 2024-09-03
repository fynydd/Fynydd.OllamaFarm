namespace Fynydd.OllamaFarm.Models;

public sealed class OllamaHost
{
    public string Address { get; set; } = string.Empty;
    public int Port { get; set; } = 11434;
    public string FullAddress => $"{Address}:{Port}";

    public static int ConnectTimeoutSeconds => 15;
    public static int RequestTimeoutSeconds => 900;

    public DateTime NextPing { get; set; } = DateTime.Now;
    public bool IsBusy { get; set; }
    public bool IsOnline { get; set; }
    public bool IsOffline => IsOnline == false;
}