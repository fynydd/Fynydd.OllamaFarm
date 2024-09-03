using System.Reflection;

namespace Fynydd.OllamaFarm;

public static class ConsoleHelper
{
    public static int MaxConsoleWidth => Console.WindowWidth - 1;
    public static int IdealConsoleWidth => Console.WindowWidth > 80 ? 80 : Console.WindowWidth - 1;

    #region Output
    
    public static void WriteLine(string text, int maxWidth = -1)
    {
        text.WriteToConsole(maxWidth > -1 ? maxWidth : MaxConsoleWidth);
    }

    public static void WriteLine()
    {
        Console.WriteLine();
    }

    public static void WriteLineFill(char character, int maxWidth = -1)
    {
        Console.WriteLine(character.ToString().Repeat(maxWidth > -1 ? maxWidth : MaxConsoleWidth));
    }

    public static void RenderHelp()
    {
        WriteLine();
        
        WriteLine("Usage:");
        WriteLine("    ollamafarm [[--port | -p] [port]] [host host host ...]");
        
        WriteLine();
        
        WriteLine("Parameters:");
        WriteLine("    [[--port | -p] [port]] : Listen to HTTP port number (defaults to 4444)");
        WriteLine("    [host host host ...]   : List of host names with optional ports");
        
        WriteLine();
        
        WriteLine("Examples:");
        WriteLine("    ollamafarm localhost 10.0.10.1 10.0.10.3");
        WriteLine("    ollamafarm --port 1234 localhost 10.0.10.1 10.0.10.3");
        WriteLine("    ollamafarm --port 1234 localhost:11234 10.0.10.1 10.0.10.3");

        WriteLine();
        
        WriteLine("Ollama Farm Requests");
        WriteLineFill('-');
        WriteLine("Make Ollama API requests to this service and they will be routed to one of the Ollama API hosts in the farm. Requests should be sent to this service (default port 4444) and follow the standard Ollama JSON request body format (HTTP POST to /api/generate/). Streaming is supported.");
        
        WriteLine();
        
        WriteLine("To optimize performance Ollama Farm restricts each host to processing one request at a time. When all hosts are busy REST calls return status code 429 (too many requests). This allows requesters to poll until a resource is available.");
        
        WriteLine();
        
        WriteLine("Additional properties:");
        WriteLine("    farm_host (requests) : Request a specific host (e.g. localhost:11434)");
        WriteLine("    farm_host (response) : Identify the host used");
        
        WriteLine();
        
        WriteLine("Example:");
        WriteLine("    { \"farm_host\": \"localhost\", \"model\": ... }");
        
        WriteLine();
    }

    public static void RenderIntro()
    {
        var version = Identify.Version(Assembly.GetExecutingAssembly());
        
        WriteLine("Ollama Farm: Combine Ollama API instances into a single Ollama API service", IdealConsoleWidth);
        WriteLine($"Version {version} for {Identify.GetOsPlatformName()} (.NET {Identify.GetRuntimeVersion()}/{Identify.GetProcessorArchitecture()})", IdealConsoleWidth);
        WriteLineFill('=', IdealConsoleWidth);
    }
    
    #endregion

    #region Key Handlers
    
    public static void AddCancelKeysWatcher(this WebApplication app, CancellationTokenSource cts)
    {
        Console.CancelKeyPress += (_, e) =>
        {
            e.Cancel = true;
            cts.Cancel();
            WriteLine($"{DateTime.Now:s} => Control+C pressed, exiting...");
        };

        _ = Task.Run(async () =>
        {
            while (cts.Token.IsCancellationRequested == false)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true);

                    if (key.Key == ConsoleKey.Escape)
                    {
                        await cts.CancelAsync();
                        WriteLine($"{DateTime.Now:s} => Escape key pressed, exiting...");
                    }
                }
                await Task.Delay(100);
            }
        });
        
    }
    
    #endregion
}