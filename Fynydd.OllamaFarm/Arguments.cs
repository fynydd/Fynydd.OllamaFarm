using Argentini.OllamaFarm.Models;

namespace Argentini.OllamaFarm;

public static class Arguments
{
    public static int GetListenPort(this string[] args)
    {
        const int DefaultPort = 4444;
        
        for (var i = 0; i < args.Length; i++)
        {
            var arg = args[i];
            
            if (string.IsNullOrEmpty(arg))
                continue;

            if (arg.Equals("--port", StringComparison.OrdinalIgnoreCase) == false && arg.Equals("-p", StringComparison.OrdinalIgnoreCase) == false)
                continue;

            if (args.Length <= ++i)
                return DefaultPort;

            if (int.TryParse(args[i], out var listenPort) == false)
            {
                ConsoleHelper.WriteLine($"Error => Specified port {args[i]} is invalid");
                Environment.Exit(1);
            }

            else if (listenPort is < 1 or > 65535)
            {
                ConsoleHelper.WriteLine($"Error => Specified port {args[i]} is out of range");
                Environment.Exit(1);
            }

            return listenPort;
        }

        return DefaultPort;
    }

    public static int GetDelayMs(this string[] args)
    {
        const int DefaultDelayMs = 0;
        
        for (var i = 0; i < args.Length; i++)
        {
            var arg = args[i];
            
            if (string.IsNullOrEmpty(arg))
                continue;

            if (arg.Equals("--delay", StringComparison.OrdinalIgnoreCase) == false && arg.Equals("-d", StringComparison.OrdinalIgnoreCase) == false)
                continue;

            if (args.Length <= ++i)
                return DefaultDelayMs;

            if (long.TryParse(args[i], out var listenPort) == false)
            {
                ConsoleHelper.WriteLine($"Error => Specified delay ms {args[i]} is invalid");
                Environment.Exit(1);
            }

            else if (listenPort is < 0 or > int.MaxValue)
            {
                ConsoleHelper.WriteLine($"Error => Specified delay ms {args[i]} is out of range");
                Environment.Exit(1);
            }

            return (int)listenPort;
        }

        return DefaultDelayMs;
    }

    public static ConcurrentBag<OllamaHost> GetHosts(this string[] args)
    {
        var hosts = new ConcurrentBag<OllamaHost>();
        
        for (var i = 0; i < args.Length; i++)
        {
            var arg = args[i];
            
            if (string.IsNullOrEmpty(arg))
                continue;

            if (arg.Equals("--port", StringComparison.OrdinalIgnoreCase) || arg.Equals("-p", StringComparison.OrdinalIgnoreCase) || arg.Equals("--delay", StringComparison.OrdinalIgnoreCase) || arg.Equals("-d", StringComparison.OrdinalIgnoreCase))
            {
                ++i;
                continue;
            }
            
            var segments = arg.Split(':', StringSplitOptions.RemoveEmptyEntries);

            if (segments.Length < 1)
                continue;

            var port = 11434;

            if (segments.Length == 2)
                if (int.TryParse(segments[1], out port) == false)
                {
                    ConsoleHelper.WriteLine($"Error => passed host {arg} specifies a port but the port is invalid");
                    Environment.Exit(1);
                }
            
            if (port is < 1 or > 65535)
            {
                ConsoleHelper.WriteLine($"Error => passed host {arg} specifies a port but the port is invalid");
                Environment.Exit(1);
            }
            
            hosts.Add(new OllamaHost
            {
                Address = segments[0],
                Port = port,
                IsOnline = true
            });
        }

        return hosts;
    }
}