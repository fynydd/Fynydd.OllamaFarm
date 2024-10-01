namespace Fynydd.OllamaFarm.Extensions;

/// <summary>
/// Various tools for working with strings. 
/// </summary>
public static class Strings
{
	#region Constants

    public static string ArrowRight => "\u2b95";
	public static string TriangleRight => "\u23f5";
	public static string ThinLine => "\u23bb";
	public static string ThickLine => "\u2501";
	
	public static Dictionary<string, string> CssNamedColors { get; } = new()
	{
	    ["aliceblue"] = "rgb(240, 248, 255)",
	    ["antiquewhite"] = "rgb(250, 235, 215)",
	    ["aqua"] = "rgb(0, 255, 255)",
	    ["aquamarine"] = "rgb(127, 255, 212)",
	    ["azure"] = "rgb(240, 255, 255)",
	    ["beige"] = "rgb(245, 245, 220)",
	    ["bisque"] = "rgb(255, 228, 196)",
	    ["black"] = "rgb(0, 0, 0)",
	    ["blanchedalmond"] = "rgb(255, 235, 205)",
	    ["blue"] = "rgb(0, 0, 255)",
	    ["blueviolet"] = "rgb(138, 43, 226)",
	    ["brown"] = "rgb(165, 42, 42)",
	    ["burlywood"] = "rgb(222, 184, 135)",
	    ["cadetblue"] = "rgb(95, 158, 160)",
	    ["chartreuse"] = "rgb(127, 255, 0)",
	    ["chocolate"] = "rgb(210, 105, 30)",
	    ["coral"] = "rgb(255, 127, 80)",
	    ["cornflowerblue"] = "rgb(100, 149, 237)",
	    ["cornsilk"] = "rgb(255, 248, 220)",
	    ["crimson"] = "rgb(220, 20, 60)",
	    ["cyan"] = "rgb(0, 255, 255)",
	    ["darkblue"] = "rgb(0, 0, 139)",
	    ["darkcyan"] = "rgb(0, 139, 139)",
	    ["darkgoldenrod"] = "rgb(184, 134, 11)",
	    ["darkgray"] = "rgb(169, 169, 169)",
	    ["darkgreen"] = "rgb(0, 100, 0)",
	    ["darkgrey"] = "rgb(169, 169, 169)",
	    ["darkkhaki"] = "rgb(189, 183, 107)",
	    ["darkmagenta"] = "rgb(139, 0, 139)",
	    ["darkolivegreen"] = "rgb(85, 107, 47)",
	    ["darkorange"] = "rgb(255, 140, 0)",
	    ["darkorchid"] = "rgb(153, 50, 204)",
	    ["darkred"] = "rgb(139, 0, 0)",
	    ["darksalmon"] = "rgb(233, 150, 122)",
	    ["darkseagreen"] = "rgb(143, 188, 143)",
	    ["darkslateblue"] = "rgb(72, 61, 139)",
	    ["darkslategray"] = "rgb(47, 79, 79)",
	    ["darkslategrey"] = "rgb(47, 79, 79)",
	    ["darkturquoise"] = "rgb(0, 206, 209)",
	    ["darkviolet"] = "rgb(148, 0, 211)",
	    ["deeppink"] = "rgb(255, 20, 147)",
	    ["deepskyblue"] = "rgb(0, 191, 255)",
	    ["dimgray"] = "rgb(105, 105, 105)",
	    ["dimgrey"] = "rgb(105, 105, 105)",
	    ["dodgerblue"] = "rgb(30, 144, 255)",
	    ["firebrick"] = "rgb(178, 34, 34)",
	    ["floralwhite"] = "rgb(255, 250, 240)",
	    ["forestgreen"] = "rgb(34, 139, 34)",
	    ["fuchsia"] = "rgb(255, 0, 255)",
	    ["gainsboro"] = "rgb(220, 220, 220)",
	    ["ghostwhite"] = "rgb(248, 248, 255)",
	    ["gold"] = "rgb(255, 215, 0)",
	    ["goldenrod"] = "rgb(218, 165, 32)",
	    ["gray"] = "rgb(128, 128, 128)",
	    ["green"] = "rgb(0, 128, 0)",
	    ["greenyellow"] = "rgb(173, 255, 47)",
	    ["grey"] = "rgb(128, 128, 128)",
	    ["honeydew"] = "rgb(240, 255, 240)",
	    ["hotpink"] = "rgb(255, 105, 180)",
	    ["indianred"] = "rgb(205, 92, 92)",
	    ["indigo"] = "rgb(75, 0, 130)",
	    ["ivory"] = "rgb(255, 255, 240)",
	    ["khaki"] = "rgb(240, 230, 140)",
	    ["lavender"] = "rgb(230, 230, 250)",
	    ["lavenderblush"] = "rgb(255, 240, 245)",
	    ["lawngreen"] = "rgb(124, 252, 0)",
	    ["lemonchiffon"] = "rgb(255, 250, 205)",
	    ["lightblue"] = "rgb(173, 216, 230)",
	    ["lightcoral"] = "rgb(240, 128, 128)",
	    ["lightcyan"] = "rgb(224, 255, 255)",
	    ["lightgoldenrodyellow"] = "rgb(250, 250, 210)",
	    ["lightgray"] = "rgb(211, 211, 211)",
	    ["lightgreen"] = "rgb(144, 238, 144)",
	    ["lightgrey"] = "rgb(211, 211, 211)",
	    ["lightpink"] = "rgb(255, 182, 193)",
	    ["lightsalmon"] = "rgb(255, 160, 122)",
	    ["lightseagreen"] = "rgb(32, 178, 170)",
	    ["lightskyblue"] = "rgb(135, 206, 250)",
	    ["lightslategray"] = "rgb(119, 136, 153)",
	    ["lightslategrey"] = "rgb(119, 136, 153)",
	    ["lightsteelblue"] = "rgb(176, 196, 222)",
	    ["lightyellow"] = "rgb(255, 255, 224)",
	    ["lime"] = "rgb(50, 205, 50)",
	    ["limegreen"] = "rgb(50, 205, 50)",
	    ["linen"] = "rgb(250, 240, 230)",
	    ["magenta"] = "rgb(255, 0, 255)",
	    ["maroon"] = "rgb(128, 0, 0)",
	    ["mediumaquamarine"] = "rgb(102, 205, 170)",
	    ["mediumblue"] = "rgb(0, 0, 205)",
	    ["mediumorchid"] = "rgb(186, 85, 211)",
	    ["mediumpurple"] = "rgb(147, 112, 219)",
	    ["mediumseagreen"] = "rgb(60, 179, 113)",
	    ["mediumslateblue"] = "rgb(123, 104, 238)",
	    ["mediumspringgreen"] = "rgb(0, 250, 154)",
	    ["mediumturquoise"] = "rgb(72, 209, 204)",
	    ["mediumvioletred"] = "rgb(199, 21, 133)",
	    ["midnightblue"] = "rgb(25, 25, 112)",
	    ["mintcream"] = "rgb(245, 255, 250)",
	    ["mistyrose"] = "rgb(255, 228, 225)",
	    ["moccasin"] = "rgb(255, 228, 181)",
	    ["navajowhite"] = "rgb(255, 222, 173)",
	    ["navy"] = "rgb(0, 0, 128)",
	    ["oldlace"] = "rgb(253, 245, 230)",
	    ["olive"] = "rgb(128, 128, 0)",
	    ["olivedrab"] = "rgb(107, 142, 35)",
	    ["orange"] = "rgb(255, 165, 0)",
	    ["orangered"] = "rgb(255, 69, 0)",
	    ["orchid"] = "rgb(218, 112, 214)",
	    ["palegoldenrod"] = "rgb(238, 232, 170)",
	    ["palegreen"] = "rgb(152, 251, 152)",
	    ["paleturquoise"] = "rgb(175, 238, 238)",
	    ["palevioletred"] = "rgb(219, 112, 147)",
	    ["papayawhip"] = "rgb(255, 239, 213)",
	    ["peachpuff"] = "rgb(255, 218, 185)",
	    ["peru"] = "rgb(205, 133, 63)",
	    ["pink"] = "rgb(255, 192, 203)",
	    ["plum"] = "rgb(221, 160, 221)",
	    ["powderblue"] = "rgb(176, 224, 230)",
	    ["purple"] = "rgb(128, 0, 128)",
	    ["rebeccapurple"] = "rgb(102, 51, 153)",
	    ["red"] = "rgb(255, 0, 0)",
	    ["rosybrown"] = "rgb(188, 143, 143)",
	    ["royalblue"] = "rgb(65, 105, 225)",
	    ["saddlebrown"] = "rgb(139, 69, 19)",
	    ["salmon"] = "rgb(250, 128, 114)",
	    ["sandybrown"] = "rgb(244, 164, 96)",
	    ["seagreen"] = "rgb(46, 139, 87)",
	    ["seashell"] = "rgb(255, 245, 238)",
	    ["sienna"] = "rgb(160, 82, 45)",
	    ["silver"] = "rgb(192, 192, 192)",
	    ["skyblue"] = "rgb(135, 206, 235)",
	    ["slateblue"] = "rgb(106, 90, 205)",
	    ["slategray"] = "rgb(112, 128, 144)",
	    ["slategrey"] = "rgb(112, 128, 144)",
	    ["snow"] = "rgb(255, 250, 250)",
	    ["springgreen"] = "rgb(0, 255, 127)",
	    ["steelblue"] = "rgb(70, 130, 180)",
	    ["tan"] = "rgb(210, 180, 140)",
	    ["teal"] = "rgb(0, 128, 128)",
	    ["thistle"] = "rgb(216, 191, 216)",
	    ["tomato"] = "rgb(255, 99, 71)",
	    ["transparent"] = "rgb(0, 0, 0, 0)",
	    ["turquoise"] = "rgb(64, 224, 208)",
	    ["violet"] = "rgb(238, 130, 238)",
	    ["wheat"] = "rgb(245, 222, 179)",
	    ["white"] = "rgb(255, 255, 255)",
	    ["whitesmoke"] = "rgb(245, 245, 245)",
	    ["yellow"] = "rgb(255, 255, 0)",
	    ["yellowgreen"] = "rgb(154, 205, 50)"	    
	};
	
	#endregion
	
	#region Trimming
	
    /// <summary>
    /// Converts two or more consecutive spaces into a single space.
    /// </summary>
    /// <param name="value">String to process</param>
    /// <returns>String with only single spaces</returns>
    public static string ConsolidateSpaces(this string value)
    {
        var regEx = new Regex(@"[\s]+");
		
        return regEx.Replace(value, " ");
    }
    
	/// <summary>
    /// Remove a specified number of characters from the beginning of a string
    /// </summary>
    /// <param name="value">String to trim</param>
    /// <param name="count">Number of characters to remove</param>
    /// <returns>Trimmed string</returns>
	public static string? TrimStart(this string? value, int count)
	{
		if (value is not null && value.Length >= count)
			return value.Right(value.Length - count);

		return value;
	}

	/// <summary>
    /// Remove a specified number of characters from the end of a string
    /// </summary>
    /// <param name="value">String to trim</param>
    /// <param name="count">Number of characters to remove</param>
    /// <returns>Trimmed string</returns>
	public static string? TrimEnd(this string? value, int count)
	{
		if (value is not null && value.Length >= count)
			return value.Left(value.Length - count);

		return value;
	}

	/// <summary>
	/// Remove a string from the beginning of a string
	/// </summary>
	/// <param name="source">The string to search</param>
	/// <param name="substring">The substring to remove</param>
	/// <param name="stringComparison"></param>
	/// <returns>Trimmed source</returns>
	public static string? TrimStart(this string? source, string? substring = " ", StringComparison stringComparison = StringComparison.Ordinal)
	{
		if (source is null || source.IsEmpty() || substring is null or "")
			return null;

		var result = new StringBuilder(source);
		
		result.TrimStart(substring, stringComparison);

		return result.ToString();
	}

	/// <summary>
	/// Remove a string from the end of a string
	/// </summary>
	/// <param name="source">The string to search</param>
	/// <param name="substring">The substring to remove</param>
	/// <param name="stringComparison"></param>
	/// <returns>Trimmed source</returns>
	public static string? TrimEnd(this string? source, string? substring = " ", StringComparison stringComparison = StringComparison.Ordinal)
	{
		if (source is null || source.IsEmpty() || substring is null or "")
			return null;

		var result = new StringBuilder(source);
		
		result.TrimEnd(substring, stringComparison);

		return result.ToString();
	}

	/// <summary>
	/// Trim directory separator characters from the end of a string base on the current operating system.
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public static string TrimEndingPathSeparators(this string? value)
	{
		if (string.IsNullOrEmpty(value))
			return string.Empty;

		return value.TrimEnd(Path.DirectorySeparatorChar).TrimEnd(Path.AltDirectorySeparatorChar);
	}
	
	#endregion
	
	#region Comparison	

	/// <summary>
	/// Determines if a string has a value (is not null and not empty).
	/// </summary>
	/// <param name="value">String to evaluate</param>
	public static bool HasValue(this string? value)
	{
		return string.IsNullOrEmpty(value?.Trim()) == false;
	}

	/// <summary>
	/// Determines if a string is empty or null.
	/// </summary>
	/// <param name="value">String to evaluate</param>
	public static bool IsEmpty(this string? value)
	{
		return string.IsNullOrEmpty(value);
	}
	
	/// <summary>
	/// Determine if two strings are not equal.
	/// </summary>
	/// <param name="source"></param>
	/// <param name="value"></param>
	/// <param name="comparisonType"></param>
	/// <returns></returns>
	public static bool NotEquals(this string? source, string? value, StringComparison comparisonType = StringComparison.Ordinal)
	{
		if (source is null && value is null) return false;
		if (source is not null && value is null) return true;
		if (source is null && value is not null) return true;
		
		return source?.Equals(value, comparisonType) == false;
	}

    /// <summary>
    /// Determine if two strings are not equal, ignoring case.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="value"></param>
    /// <param name="comparisonType"></param>
    /// <returns></returns>
    public static bool InvariantNotEquals(this string? source, string? value)
    {
        if (source is null && value is null) return false;
        if (source is not null && value is null) return true;
        if (source is null && value is not null) return true;
		
        return source?.Equals(value, StringComparison.InvariantCultureIgnoreCase) == false;
    }

    /// <summary>
    /// Determine if two strings are equal, ignoring case.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="value"></param>
    /// <param name="comparisonType"></param>
    /// <returns></returns>
    public static bool InvariantEquals(this string? source, string? value)
    {
        return source.InvariantNotEquals(value) == false;
    }

	/// <summary>
	/// Determine if a string starts with any value from a string array.
	/// </summary>
	/// <param name="value"></param>
	/// <param name="substrings"></param>
	/// <param name="stringComparison"></param>
	/// <returns></returns>
	public static bool StartsWith(this string value, string[]? substrings, StringComparison stringComparison = StringComparison.Ordinal)
	{
		if (substrings is not {Length: > 0}) return false;

		var result = false;
        
		for (var x = 0; x < substrings.Length; x++)
		{
			if (value.StartsWith(substrings[x], stringComparison) == false) continue;
            
			result = true;
			x = substrings.Length;
		}

		return result;
	}
	
	#endregion
	
	#region Parsing

	/// <summary>
	/// Get the index of the first non-space character in a string.
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public static int FirstNonSpaceCharacter(this string? value)
	{
		if (string.IsNullOrEmpty(value))
			return 0;

		var index = -1;
		
		foreach (var c in value)
		{
			index++;

			if (char.IsWhiteSpace(c))
				continue;
			
			break;
		}

		return index;
	}
	
	/// <summary>
	/// Get the left "length" characters of a string.
	/// </summary>
	/// <param name="value">String value</param>
	/// <param name="length">Number of characters</param>
	/// <returns>Left portion of a string</returns>
	public static string Left(this string? value, int length)
	{
		if (value is null || value.IsEmpty() || length < 1) return string.Empty;
		if (length > value.Length) return value;
		
		return value[..length];
	}

	/// <summary>
	/// Get the left characters of a string up to but not including the first instance of "marker".
	/// If marker is not found the original value is returned.
	/// </summary>
	/// <param name="value">String value</param>
	/// <param name="marker">Delimiter to denote the cut off point</param>
	/// <returns>Left portion of a string</returns>
	public static string Left(this string? value, string? marker)
	{
		if (value is null || value.IsEmpty()) return string.Empty;
		if (marker is null || marker.IsEmpty()) return value;

		if (value.Length <= marker.Length) return string.Empty;

		if (value.Contains(marker))
			return value[..value.IndexOf(marker, StringComparison.Ordinal)];

		return value;
	}
	
	/// <summary>
	/// Get the right "length" characters of a string.
	/// </summary>
	/// <param name="value">String value</param>
	/// <param name="length">Number of characters</param>
	/// <returns>Right portion of a string</returns>
	public static string Right(this string? value, int length)
	{
		if (value is null || value.IsEmpty() || length < 1) return string.Empty;
		if (length > value.Length) return value;

		return value[^length..];
	}

	/// <summary>
	/// Get the right characters of a string up to but not including the last instance of "marker" (right to left).
	/// If marker is not found the original value is returned.
	/// </summary>
	/// <param name="value">String value</param>
	/// <param name="marker">Delimiter to denote the cut off point</param>
	/// <returns>Right portion of a string</returns>
	public static string Right(this string? value, string? marker)
	{
		if (value is null || value.IsEmpty()) return string.Empty;
		if (marker is null || marker.IsEmpty()) return value;

		if (value.Length <= marker.Length) return string.Empty;
		
		if (value.Contains(marker))
			return value[(value.LastIndexOf(marker, StringComparison.Ordinal) + marker.Length)..];

		return value;
	}
	
	#endregion
	
	#region Transformations

    public static string ToSentenceCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        return char.ToUpper(input[0]) + input[1..];
    }
    
	/// <summary>
	/// When indenting a complex RegEx use this to make it one line again.
	/// </summary>
	/// <param name="regex"></param>
	/// <returns></returns>
	public static string CleanUpIndentedRegex(this string regex)
	{
		return regex
			.Replace("\r", string.Empty)
			.Replace("\n", string.Empty)
			.Replace("\t", string.Empty)
			.Replace(" ", string.Empty);
	}

	/// <summary>
	/// Removes spaces and newlines from a string.
	/// </summary>
	/// <param name="css"></param>
	/// <returns></returns>
	public static string CompactCss(this string css)
    {
        var result = Regex.Replace(css.NormalizeLinebreaks(), @"\s+", " ").Trim();

        result = result.Replace(": ", ":");

        return result;
    }
	
	/// <summary>
	/// Repeat a string a specified number of times.
	/// </summary>
	/// <param name="text"></param>
	/// <param name="n"></param>
	/// <returns></returns>
	public static string Repeat(this string text, int n)
	{
		if (string.IsNullOrEmpty(text) || n < 1)
			return string.Empty;
		
		var textAsSpan = text.AsSpan();
		var span = new Span<char>(new char[textAsSpan.Length * n]);
	
		for (var i = 0; i < n; i++)
		{
			textAsSpan.CopyTo(span.Slice(i * textAsSpan.Length, textAsSpan.Length));
		}

		return span.ToString();
	}
	
	/// <summary>
	/// Indent text with whitespace based on line breaks
	/// </summary>
	/// <param name="block"></param>
	/// <param name="count"></param>
	/// <returns></returns>
	public static string Indent(this string block, int count)
	{
		if (string.IsNullOrEmpty(block))
			return block;

        if (count < 0)
            count = 0;

        if (count == 0)
            return block;
        
		var whitespace = " ".Repeat(count);
		var result = block.Replace("\n", $"\n{whitespace}");

		if (result.EndsWith($"\n{whitespace}"))
			result = result[..^count];
		
		return (result.StartsWith('\r') || result.StartsWith('\n') ? string.Empty : whitespace) + result;
	}
	
	/// <summary>
	/// Normalize line breaks.
	/// </summary>
	/// <param name="value"></param>
	/// <param name="linebreak">Line break to use (default: "\n")</param>
	public static string NormalizeLinebreaks(this string value, string linebreak = "\n")
	{
		if (value.IsEmpty())
			return string.Empty;

		if (value.Contains('\r'))
		{
			if (linebreak != "\r\n")
				return value.Replace("\r\n", linebreak);
		}

		else
		{
			if (linebreak != "\n")
				return value.Replace("\n", linebreak);
		}
		
		return value;        
	}

	/// <summary>
	/// Normalize path separators to those used by the current OS.
	/// </summary>
	/// <param name="value"></param>
	public static string SetNativePathSeparators(this string value)
	{
		if (string.IsNullOrEmpty(value))
			return string.Empty;

		if (Path.DirectorySeparatorChar == '/')
			return value.Replace('\\', '/');

        return value.Replace('/', '\\');
	}

    /// <summary>
    /// Normalize path separators to those used by the SMB protocol.
    /// </summary>
    /// <param name="value"></param>
    public static string SetSmbPathSeparators(this string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;

        if (value.IndexOf('/') > -1)
            return value.Replace('/', '\\');        

        return value;        
    }

	/// <summary>
	/// Convert bytes into a user-friendly size (e.g. 1024 becomes 1kb).
	/// </summary>
	/// <param name="val">Number of bytes</param>
	/// <param name="forStorage">When true sizes are calculated using base 10 (so 1kb = 1,000 bytes), false uses base 2 (so 1kb = 1,024 bytes).false Defaults to true</param>
	/// <returns>User-friendly size representation</returns>
	public static string FormatBytes<T>(this T val, bool forStorage = true)
	{
		var value = Convert.ToDecimal(val);
		var result = "0 bytes";
		decimal divisor = 1000;
		var mb = (divisor * divisor);
		var gb = (mb * divisor);
		var tb = (gb * divisor);
		var pb = (tb * divisor);

		if (forStorage == false)
		{
			divisor = 1024;
		}

		if (value <= 0)
			return result;
		
		// BYTES
		if (value < divisor)
		{
			result = (value.ToString("#,##0")) + " bytes";
		}

		// KILOBYTE
		if (value >= divisor && value < mb)
		{
			var newVal = (value / divisor);
			result = (newVal.ToString("#,##0.#")) + "kb";
		}

		// MEGABYTES
		if (value >= mb && value < gb)
		{
			var newVal = (value / divisor) / divisor;
			result = (newVal.ToString("#,##0.#")) + "mb";
		}

		// GIGABYTES
		if (value >= gb && value < tb)
		{
			var newVal = ((value / divisor) / divisor) / divisor;
			result = (newVal.ToString("#,##0.#")) + "gb";
		}

		// TERABYTES
		if (value >= tb && value < pb)
		{
			var newVal = (((value / divisor) / divisor) / divisor) / divisor;
			result = (newVal.ToString("#,##0.#")) + "tb";
		}

		// PETABYTES
		if (value >= pb)
		{
			var newVal = ((((value / divisor) / divisor) / divisor) / divisor) / divisor;
			result = (newVal.ToString("#,##0.#")) + "pb";
		}

		return result;
	}

	/// <summary>
	/// Convert a numeric pixel value to a rem value string, including the "rem" unit.
	/// </summary>
	/// <param name="pixels"></param>
	/// <returns></returns>
	public static string PxToRem(this decimal pixels)
	{
		return $"{(pixels / 16m):#0.######}rem";
	}

	/// <summary>
	/// Convert a numeric pixel value to a rem value string, including the "rem" unit.
	/// </summary>
	/// <param name="pixels"></param>
	/// <returns></returns>
	public static string PxToRem(this int pixels)
	{
		return $"{(pixels / 16m):#0.######}rem";
	}

    /// <summary>
    /// Convert a numeric pixel value to a rem value string, including the "rem" unit.
    /// </summary>
    /// <param name="pixels"></param>
    /// <returns></returns>
    public static string PxToRem(this double pixels)
    {
        return $"{(pixels / 16):#0.######}rem";
    }

	/// <summary>
	/// Convert a pixel string value to a rem value string, including the "rem" unit.
	/// </summary>
	/// <param name="pixels"></param>
	/// <returns></returns>
	public static string PxToRem(this string pixelVal)
	{
		if (decimal.TryParse(pixelVal.Trim().TrimEnd("px")?.Trim(), out var pixels) == false)
			return "0rem";
		
		return $"{(pixels / 16):#0.######}rem";
	}

	/// <summary>
	/// Convert a web color to an rgba() value.
	/// Handles rgb() and hex colors.
	/// Optionally set a new opacity value (0-100).
	/// </summary>
	/// <param name="color"></param>
	/// <param name="opacity"></param>
	/// <returns>rgba() value, or rgba(0,0,0,-0) on error</returns>
	public static string WebColorToRgba(this string color, int opacity)
	{
		return color.WebColorToRgba(opacity / 100m);
	}

	/// <summary>
	/// Convert a web color to an rgba() value.
	/// Handles rgb() and hex colors.
	/// Optionally set a new opacity value (0-1.0).
	/// </summary>
	/// <param name="color"></param>
	/// <param name="opacity"></param>
	/// <returns>rgba() value, or rgba(0,0,0,-0) on error</returns>
	public static string WebColorToRgba(this string color, double opacity)
	{
		return color.WebColorToRgba((decimal)opacity);
	}
	
	/// <summary>
	/// Convert a web color (hex, rgb, or named) to an rgba() value.
	/// Handles rgb() and hex colors.
	/// Optionally set a new opacity value (0-1.0).
	/// </summary>
	/// <param name="color"></param>
	/// <param name="opacity"></param>
	/// <returns>rgba() value, or rgba(0,0,0,-0) on error</returns>
	public static string WebColorToRgba(this string color, decimal? opacity = null)
	{
		const string errorValue = "rgba(0,0,0,-0)";

		if (opacity > 1)
			opacity = 1;

		if (opacity < 0)
			opacity = 0;
		
		color = color.Replace(" ", string.Empty);

		var rgbIndex = color.IndexOf("rgb", StringComparison.Ordinal);
		var hexIndex = color.IndexOf('#');

		if (hexIndex == -1 && rgbIndex == -1)
		{
			if (CssNamedColors.TryGetValue(color, out var namedColor))
			{
				color = namedColor;
				rgbIndex = color.IndexOf("rgb", StringComparison.Ordinal);
			}
		}
		
		if (rgbIndex == 0)
		{
			color = color.TrimStart("rgb(") ?? string.Empty;
			color = color.TrimStart("rgba(") ?? string.Empty;
			color = color.TrimEnd(';');
			color = color.TrimEnd(')');

			var segments = color.Split(',', StringSplitOptions.RemoveEmptyEntries);

			if (segments.Length != 3 && segments.Length != 4)
				return errorValue;

			if (int.TryParse(segments[0].Trim('-'), out var red) == false)
				return errorValue;
			
			if (int.TryParse(segments[1].Trim('-'), out var green) == false)
				return errorValue;

			if (int.TryParse(segments[2].Trim('-'), out var blue) == false)
				return errorValue;

			if (red < 0 || green < 0 || blue < 0)
				return errorValue;

			if (red > 255 || green > 255 || blue > 255)
				return errorValue;
			
			var alpha = 1m;

			if (segments.Length == 4)
				_ = decimal.TryParse(segments[3].Trim('-'), out alpha);

			if (alpha < 0)
				alpha = 0;

			if (alpha > 1)
				alpha = 1;

			return $"rgba({red},{green},{blue},{(opacity is null ? $"{alpha:0.##}" : $"{opacity:0.##}")})";
		}

		if (hexIndex != 0)
			return errorValue;
			
		color = color[1..];

		if (color.Length is not (3 or 4 or 6 or 8))
			return errorValue;
	
		if (color.Length is 3)
			color = color[0].ToString() + color[0] + color[1] + color[1] + color[2] + color[2];

		if (color.Length is 4)
			color = color[0].ToString() + color[0] + color[1] + color[1] + color[2] + color[2] + color[3] + color[3];

		var r = Convert.ToInt32(color[..2], 16);
		var g = Convert.ToInt32(color.Substring(2, 2), 16);
		var b = Convert.ToInt32(color.Substring(4, 2), 16);
		var a = 1m;

		if (color.Length == 8)
		{
			var alpha = Convert.ToInt32(color[6..], 16);
			a = Math.Round((decimal)alpha / 255, 2);
		}

		if (opacity is null)
			return $"rgba({r},{g},{b},{a:0.##})";

		return $"rgba({r},{g},{b},{opacity:0.##})";
	}
	
	#endregion
	
	#region Time

	/// <summary>
	/// Format the elapsed time as a more friendly time span with a custom delimitter.
	/// Like: 3d : 5h : 12m : 15s or 3d+5h+12m+15s
	/// </summary>
	/// <param name="timer"></param>
	/// <param name="delimitter">Text to separate time elements; defaults to " : ".</param>
	/// <returns>Formatted timespan</returns>
	public static string FormatTimer(this Stopwatch timer, string delimitter = ":")
	{
		return FormatTimer(TimeSpan.FromMilliseconds(timer.ElapsedMilliseconds), delimitter);
	}
	
	/// <summary>
	/// Format the elapsed time as a more friendly time span with a custom delimitter.
	/// Like: 3d : 5h : 12m : 15s or 3d+5h+12m+15s
	/// </summary>
	/// <param name="timespan"></param>
	/// <param name="delimiter">Text to separate time elements; defaults to " : ".</param>
	/// <returns>Formatted timespan</returns>
	public static string FormatTimer(this TimeSpan timespan, string delimiter = ":")
	{
        return $"{timespan.Minutes:#00}m{delimiter}{timespan.Seconds:00}.{timespan.Milliseconds:000}s";
	}
	
	#endregion

    #region Console

    public static IEnumerable<string> WrapTextAtMaxWidth(string input, int maxLength, int indent = 0)
    {
        var result = new List<string>();
        var indentation = " ".Repeat(indent);
        var words = input.TrimStart().Split(' ');
        var currentLineLength = indentation.Length;
        var currentLine = new StringBuilder(indentation);
        var bulletIndentation = string.Empty;

        if (input.Trim().StartsWith("- ") || input.Trim().StartsWith("* "))
            bulletIndentation = "  ";
	    
        foreach (var word in words)
        {
            if (currentLineLength + word.Length + (result.Count > 0 ? bulletIndentation.Length : 0) > maxLength)
            {
                result.Add($"{(result.Count > 0 ? bulletIndentation : string.Empty)}{currentLine}");
                currentLine.Clear();
                currentLine.Append(indentation);
                currentLineLength = indentation.Length;
            }

            currentLine.Append(word);
            currentLine.Append(' ');
            currentLineLength += word.Length + 1;
        }

        if (currentLine.Length > indentation.Length + (result.Count > 0 ? bulletIndentation.Length : 0))
            result.Add($"{(result.Count > 0 ? bulletIndentation : string.Empty)}{currentLine}");

        return result;
    }
	
    public static void WriteToConsole(this string text, int maxCharacters)
    {
        if (string.IsNullOrEmpty(text))
        {
            Console.WriteLine();
            return;
        }

        var result = new List<string>();
        var indent = text.StartsWith(' ') ? text.TakeWhile(c => c == ' ').Count() : 0;
        var lines = text.Trim().NormalizeLinebreaks().Replace("_\n", " ").Split('\n');

        foreach (var line in lines)
            result.AddRange(WrapTextAtMaxWidth(line, maxCharacters, indent));

        foreach (var line in result)
        {
            Console.WriteLine(line.NormalizeLinebreaks(Environment.NewLine));
        }
    }

    #endregion
    
    public static string MakeRelativePath(this string? path)
    {
        return path?.Trim('/').Trim('\\').SetNativePathSeparators() ?? string.Empty;
    }

    public static void NormalizePaths(this List<string> source)
    {
        var list = new List<string>();
        
        foreach (var path in source)
            list.Add(path.MakeRelativePath());

        source.Clear();
        source.AddRange(list);
    }

    public static string GetLastPathSegment(this string filePath)
    {
        if (filePath.IndexOf('\\') < 0 && filePath.IndexOf('/') < 0)
            return filePath;
        
        if (filePath.IndexOf('\\') > -1)
            return filePath.MakeRelativePath()[filePath.LastIndexOf('\\')..].TrimStart('\\');

        if (filePath.IndexOf('/') > -1)
            return filePath.MakeRelativePath()[filePath.LastIndexOf('/')..].TrimStart('/');

        return filePath;
    }

    public static string FormatElapsedTime(this TimeSpan elapsed)
    {
        if (elapsed.TotalSeconds < 60)
            return $"{elapsed.Seconds:N0}.{elapsed.Milliseconds:000}s";

        if (elapsed.TotalSeconds < 3600)
            return $"{elapsed.Minutes:N0}m {elapsed.Seconds:N0}s";

        if (elapsed.TotalSeconds < 86400)
            return $"{elapsed.Hours:N0}h {elapsed.Minutes:N0}m {elapsed.Seconds:N0}s";
        
        return $"{elapsed.Days:N0}d {elapsed.Hours:N0}h {elapsed.Minutes:N0}m {elapsed.Seconds:N0}s left";
    }

    public static string Pluralize(this int value, string singular, string plural)
    {
        return value == 1 ? singular : plural;
    }
}
