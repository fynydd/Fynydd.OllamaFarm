using System.Reflection;
using System.Runtime.Versioning;

namespace Fynydd.OllamaFarm.Extensions;

public static class Identify
{
    #region OS and Runtime

    /// <summary>
    /// Get OS platform.
    /// </summary> 
    /// <returns>OSPlatform object</returns> 
    // ReSharper disable once MemberCanBePrivate.Global
    public static OSPlatform GetOsPlatform()
    {
        var osPlatform = OSPlatform.Create("Other platform");

        // Check if it's windows 
        var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        osPlatform = isWindows ? OSPlatform.Windows : osPlatform;

        // Check if it's osx 
        var isOsx = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        osPlatform = isOsx ? OSPlatform.OSX : osPlatform;

        // Check if it's Linux 
        var isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        osPlatform = isLinux ? OSPlatform.Linux : osPlatform;

        return osPlatform;
    }

    /// <summary>
    /// Get OS platform name for output to users.
    /// </summary> 
    /// <returns>OSPlatform name (friendly for output)</returns> 
    public static string GetOsPlatformName()
    {
        if (GetOsPlatform() == OSPlatform.OSX)
            return "macOS";

        if (GetOsPlatform() == OSPlatform.Linux)
            return "Linux";

        if (GetOsPlatform() == OSPlatform.Windows)
            return "Windows";

        return "Other";
    }

    /// <summary>
    /// Get the .NET Core runtime version (e.g. "2.2").
    /// </summary> 
    /// <returns>String with the .NET Core version number</returns> 
    public static string GetFrameworkVersion()
    {
        var result = Assembly
            .GetEntryAssembly()?
            .GetCustomAttribute<TargetFrameworkAttribute>()?
            .FrameworkName;

        if (result is null || result.IsEmpty()) return string.Empty;

        if (result.Contains("Version="))
            return result.Right("Version=").TrimStart(new[] { 'v' });

        return result;
    }

    /// <summary>
    /// Get the .NET CLR runtime version (e.g. "4.6.27110.04").
    /// Only works in 2.2 or later.
    /// </summary> 
    /// <returns>String with the .NET CLR runtime version number</returns> 
    public static string GetRuntimeVersion()
    {
        return RuntimeInformation.FrameworkDescription.Right(" ");
    }

    /// <summary>
    /// Get the .NET CLR runtime version string.
    /// Only works in 2.2 or later.
    /// </summary> 
    /// <returns>String with the .NET CLR runtime version number</returns> 
    public static string GetRuntimeVersionFull()
    {
        return RuntimeInformation.FrameworkDescription;
    }

    /// <summary>
    /// Get the current processor architecture.
    /// </summary>
    /// <returns></returns>
    public static Architecture GetProcessorArchitecture()
    {
        return RuntimeInformation.ProcessArchitecture;
    }

    #endregion

    #region App Version Methods

    public static string AppMajorVersion(Assembly assembly)
    {
        var result = string.Empty;

        try
        {
            result = assembly.GetName().Version?.Major.ToString();
        }

        catch (Exception e)
        {
            Console.WriteLine($"AppMajorVersion Exception: {e.Message}");
        }

        return result ?? string.Empty;
    }

    public static string AppMinorVersion(Assembly assembly)
    {
        var result = string.Empty;

        try
        {
            result = assembly.GetName().Version?.Minor.ToString();
        }

        catch (Exception e)
        {
            Console.WriteLine($"AppMinorVersion Exception: {e.Message}");
        }

        return result ?? string.Empty;
    }

    public static string AppBuildVersion(Assembly assembly)
    {
        var result = string.Empty;

        try
        {
            result = assembly.GetName().Version?.Build.ToString();
        }

        catch (Exception e)
        {
            Console.WriteLine($"AppBuildVersion Exception: {e.Message}");
        }

        return result ?? string.Empty;
    }

    public static string AppRevisionVersion(Assembly assembly)
    {
        var result = string.Empty;

        try
        {
            result = assembly.GetName().Version?.Revision.ToString();
        }

        catch (Exception e)
        {
            Console.WriteLine($"AppRevisionVersion Exception: {e.Message}");
        }

        return result ?? string.Empty;
    }

    public static string Version(Assembly assembly)
    {
        var result = string.Empty;

        try
        {
            result = AppMajorVersion(assembly) + "." + AppMinorVersion(assembly) + "." + AppBuildVersion(assembly);
        }

        catch (Exception e)
        {
            Console.WriteLine($"Version Exception: {e.Message}");
        }

        return result;
    }

    #endregion
}