namespace Fynydd.OllamaFarm.Extensions;

public static class Objects
{
    /// <summary>
    /// Get all types that inherit from a base type
    /// </summary>
    /// <param name="baseType"></param>
    /// <param name="excludeSystemAssemblies"></param>
    /// <returns></returns>
    public static IEnumerable<Type> GetInheritedTypes(this Type baseType, bool excludeSystemAssemblies = true)
    {
        var types = new List<Type>();
		
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies().Where(a => excludeSystemAssemblies == false || (excludeSystemAssemblies && (a.FullName?.StartsWith("System") ?? false) == false && (a.FullName?.StartsWith("Microsoft") ?? false) == false)))
        {
            var subtypes = assembly.GetTypes().Where(theType => theType is { IsClass: true, IsAbstract: false }).ToList();
            var ts = subtypes.Where(t => t != baseType && t.IsAssignableTo(baseType)).ToList();
            
            types.AddRange(ts);
        }
		
        return types;
    }

    #region Dictionaries
    
    /// <summary>
    /// Add or update a Dictionary<string,string> with a given key/value pair.
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="propertyTemplate"></param>
    /// <returns></returns>
    public static bool TryAddUpdate(this Dictionary<string,string> dictionary, string key, string value, string propertyTemplate = "")
    {
        if (dictionary.ContainsKey(key) == false)
            return dictionary.TryAdd(key, propertyTemplate == string.Empty ? value : propertyTemplate.Replace("{value}", value));
        
        dictionary[key] = propertyTemplate == string.Empty ? value : propertyTemplate.Replace("{value}", value);
        return true;
    }
    
    /// <summary>
    /// Add or update a Dictionary<string,string> with a given key/value pair.
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="kvp"></param>
    /// <param name="propertyTemplate"></param>
    /// <returns></returns>
    public static bool TryAddUpdate(this Dictionary<string,string> dictionary, KeyValuePair<string,string> kvp, string propertyTemplate = "")
    {
        if (dictionary.ContainsKey(kvp.Key) == false)
            return dictionary.TryAdd(kvp.Key, propertyTemplate == string.Empty ? kvp.Value : propertyTemplate.Replace("{value}", kvp.Value));
        
        dictionary[kvp.Key] = propertyTemplate == string.Empty ? kvp.Value : propertyTemplate.Replace("{value}", kvp.Value);
        return true;
    }
    
    #endregion
}