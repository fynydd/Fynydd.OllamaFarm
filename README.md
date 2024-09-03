# Ollama Farm

Ollama Farm is a CLI tool that intermediates REST API calls to multiple ollama API services. Simply make calls to the Ollama Farm REST API as if it were an ollama REST API and the rest is handled for you.

## Installation

Install dotnet 8 or later from [https://dotnet.microsoft.com/en-us/download](https://dotnet.microsoft.com/en-us/download) and then install Ollama Farm with the following command:

```
dotnet tool install --global fynydd.ollamafarm
```

You should relaunch Terminal/cmd/PowerShell so that the system path will be reloaded and the *ollamafarm* command can be found. If you've previously installed the *dotnet* runtime, this won't be necessary.

You can update to the latest version using the command below.

```
dotnet tool update --global fynydd.ollamafarm
```

You can remove the tool from your system using the command below.

```
dotnet tool uninstall --global fynydd.ollamafarm
```

## Usage

Ollama Farm is a system-level command line interface application (CLI). After installing you can access Ollama Farm at any time.

To get help on the available commands, just run `ollamafarm` in Terminal, cmd, or PowerShell. This will launch the application in help mode which displays the commands and options.

```
ollamafarm
```

For example, you can launch Ollama Farm with one or more host addresses to include in the farm:

```
ollamafarm localhost 192.168.0.5 192.168.0.6
```

In this example, Ollama Farm will listen on port 4444 for requests to `/api/generate`. The requests are standard Ollama API REST requests: HTTP POST with a JSON payload. Requests will get sent to the first available host in the farm.

You can also change the default Ollama Farm listening port of 4444:

```
ollamafarm --port 5555 localhost 192.168.0.5 192.168.0.6
```

And if you run any ollama hosts on a port other than 11434, just specify the port in the host names using colon syntax:

```
ollamafarm --port 5555 localhost:12345 192.168.0.5 192.168.0.6
```
## Ollama Farm Requests

Requests made to the Ollama Farm service will be routed to one of the available Ollama API hosts in the farm. Requests should be sent to this service (default port 4444) following the standard Ollama JSON request format (HTTP POST to **/api/generate/**). *Streaming is supported*.

Hosts are checked periodically and are taken offline when they are unavailable. They are also brought back online when they become available.

**To optimize performance Ollama Farm restricts each host to processing one request at a time.** When all hosts are busy REST calls return status code **429** (too many requests). This allows requesters to poll until a resource is available.

### Additional Properties

- **farm_host** : Request a specific host (e.g. localhost:11434)
- **farm_host** : Identify the host used

#### Example:
```
{
    "farm_host": "localhost",
    "model": ...
}
```