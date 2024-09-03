using System.Buffers.Text;

namespace Fynydd.OllamaFarm.Extensions;

/// <summary>
/// The Encoders class contains methods and properties for
/// encoding and decoding data.
/// </summary>
public static class Encoders
{
    private const byte SlashByte = (byte)'/';
    private const byte PlusByte = (byte)'+';

    private const char Hyphen = '-';
    private const char Underscore = '_';
    private const char Equal = '=';

	#region Base64 (bytes) 
	
	/// <summary>
	/// Base64 encodes a byte array.
	/// </summary>
	/// <example>
	/// <code>
	/// string encodedString = bytes.ToBase64String();
	/// </code>
	/// </example>
	/// <param name="inputBytes">A byte array to encode</param>
	/// <returns>A Base64-encoded string.</returns>
	public static string ToBase64String(this byte[]? inputBytes)
	{
		if (inputBytes is null) return string.Empty;
	
		return Convert.ToBase64String(inputBytes);
	}
	
	/// <summary>
	/// Base64 decodes a string to a byte array.
	/// </summary>
	/// <example>
	/// <code>
	/// byte[] decodedBytes = value.FromBase64String();
	/// </code>
	/// </example>
	/// <param name="encodedString">A Base64-encoded string</param>
	/// <returns>A decoded byte array.</returns>
	public static byte[]? FromBase64String(this string? encodedString)
	{
		if (encodedString is null || string.IsNullOrEmpty(encodedString))
            return default;

		return Convert.FromBase64String(encodedString);
	}

	#endregion
	
	#region Url Base64
	
	/// <summary>
	/// Base64Url-encodes a string. Safe for use in URL parameters.
	/// Removes padding and replaces + with - and / with _.
	/// </summary>
	/// <example>
	/// <code>
	/// string encodedString = bytes.ToUrlBase64String();
	/// </code>
	/// </example>
	/// <param name="inputBytes">A byte array to encode</param>
	/// <returns>A Base64Url-encoded string.</returns>
	public static string ToUrlBase64String(this byte[]? inputBytes)
	{
		if (inputBytes is not {Length: > 0}) return string.Empty;

		var result = Convert.ToBase64String(inputBytes)
			.Split(['='])[0] // Remove padding
			.Replace('+', '-') // 62nd char of encoding
			.Replace('/', '_'); // 63rd char of encoding

		return result;
	}

	/// <summary>
	/// Base64Url-encodes a string. Safe for use in URL parameters.
	/// Removes padding and replaces + with - and / with _.
	/// </summary>
	/// <example>
	/// <code>
	/// string encodedString = value.ToUrlBase64String();
	/// </code>
	/// </example>
	/// <param name="inputString">A string to encode</param>
	/// <returns>A Base64Url-encoded string.</returns>
	public static string ToUrlBase64String(this string inputString)
	{
		if (string.IsNullOrEmpty(inputString))
            return string.Empty;
		
		return Encoding.UTF8.GetBytes(inputString).ToUrlBase64String();
	}

	/// <summary>
	/// Decodes a Url Base64 string created with ToUrlBase64String().
	/// Works with strings and byte arrays.
	/// Handles missing padding characters.
	/// </summary>
	/// <example>
	/// <code>
	/// <![CDATA[
	/// byte[] decodedBytes = value.FromUrlBase64String<byte[]>();
	/// string decodedString = value.FromUrlBase64String<string>();
	/// ]]>
	/// </code>
	/// </example>
	/// <param name="encodedString">A Url Base64-encoded string</param>
	/// <returns>A decoded byte array or string.</returns>
	private static T? FromUrlBase64String<T>(this string? encodedString)
	{
		if (encodedString is null || string.IsNullOrEmpty(encodedString))
            return default;

		var base64String = encodedString
			.Replace('-', '+') // 62nd char of encoding
			.Replace('_', '/'); // 63rd char of encoding

		switch (base64String.Length % 4) // Pad with trailing '='s
		{
			case 0:
				break; // No padding needed
			case 2:
				base64String += "==";
				break;
			case 3:
				base64String += "=";
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(encodedString),
					"Encoders.FromUrlBase64String(): Invalid encoding");
		}

		var bytes = Convert.FromBase64String(base64String);
		
		if (typeof(T) == typeof(string))
			return (T)(object)Encoding.UTF8.GetString(bytes);

		if (typeof(T) == typeof(byte[]))
			return (T)(object)bytes;

		return default;
	}

	/// <summary>
	/// Decodes a Url Base64 string created with ToUrlBase64String().
	/// Handles missing padding characters.
	/// </summary>
	/// <example>
	/// <code>
	/// <![CDATA[
	/// byte[] decodedBytes = value.ToBytesFromUrlBase64String();
	/// ]]>
	/// </code>
	/// </example>
	/// <param name="encodedString">A Url Base64-encoded string</param>
	/// <returns>A decoded byte array or string.</returns>
	public static byte[]? ToBytesFromUrlBase64String(this string? encodedString)
	{
		return encodedString.FromUrlBase64String<byte[]>();
	}
	
	/// <summary>
	/// Decodes a Url Base64 string created with ToUrlBase64String().
	/// Handles missing padding characters.
	/// </summary>
	/// <example>
	/// <code>
	/// <![CDATA[
	/// string decodedString = value.ToStringFromUrlBase64String();
	/// ]]>
	/// </code>
	/// </example>
	/// <param name="encodedString">A Url Base64-encoded string</param>
	/// <returns>A decoded byte array or string.</returns>
	public static string? ToStringFromUrlBase64String(this string? encodedString)
	{
		return encodedString.FromUrlBase64String<string>();
	}
	
	#endregion
	
	#region GUIDs
	
	/// <summary>
	/// Shrink a GUID to a 22 character string value
	/// </summary>
	/// <param name="guid"></param>
	/// <returns></returns>
	public static string ShrinkGuid(this Guid guid)
    {
        Span<byte> guidBytes = stackalloc byte[16];
        Span<byte> base64Bytes = stackalloc byte[24];

        MemoryMarshal.TryWrite(guidBytes, in guid);
        Base64.EncodeToUtf8(guidBytes, base64Bytes, out _, out _);

        Span<char> finalChars = stackalloc char[22];

        for (var i = 0; i < 22; i++)
        {
            finalChars[i] = base64Bytes[i] switch
            {
                SlashByte => Hyphen,
                PlusByte => Underscore,
                _ => (char)base64Bytes[i]
            };
        }
        
 		return new string(finalChars);
	}

    /// <summary>
	/// Convert a 22-character shrunken GUID back into a proper GUID.
	/// </summary>
	/// <param name="tinyGuid"></param>
	/// <returns></returns>
	public static Guid? ExpandGuid(this ReadOnlySpan<char> tinyGuid)
    {
        Span<char> base64Chars = stackalloc char[24];

        for (var i = 0; i < 22; i++)
        {
            base64Chars[i] = tinyGuid[i] switch
            {
                '-' => '/',
                '_' => '+',
                _ => tinyGuid[i]
            };
        }

        base64Chars[22] = Equal;
        base64Chars[23] = Equal;

        Span<byte> guidBytes = stackalloc byte[16];

        Convert.TryFromBase64Chars(base64Chars, guidBytes, out _);

        return new Guid(guidBytes);        
	}
	
	#endregion
    
    #region CRC
    
    /// <summary>
    /// Calculate the CRC-32 of a string.
    /// </summary>
    public static uint Crc32(this string payload)
    {
        if (string.IsNullOrEmpty(payload))
            return 0;
		
        var encoding = new UTF8Encoding();

        return encoding.GetBytes(payload).Crc32();
    }

    /// <summary>
    /// Calculate the CRC-32 of a byte array.
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public static uint Crc32(this IEnumerable<byte> payload)
    {
        const uint sGenerator = 0xEDB88320;

        var mChecksumTable = Enumerable.Range(0, 256).Select(i =>
        {
            var tableEntry = (uint)i;

            for (var j = 0; j < 8; ++j)
            {
                tableEntry = ((tableEntry & 1) != 0)
                    ? (sGenerator ^ (tableEntry >> 1))
                    : (tableEntry >> 1);
            }

            return tableEntry;

        }).ToArray();

        try
        {
            // Initialize checksumRegister to 0xFFFFFFFF and calculate the checksum.
            return ~payload.Aggregate(0xFFFFFFFF, (checksumRegister, currentByte) =>
                (mChecksumTable[(checksumRegister & 0xFF) ^ Convert.ToByte(currentByte)] ^ (checksumRegister >> 8)));
        }
        catch (FormatException e)
        {
            throw new Exception("Could not read the stream out as bytes.", e);
        }
        catch (InvalidCastException e)
        {
            throw new Exception("Could not read the stream out as bytes.", e);
        }
        catch (OverflowException e)
        {
            throw new Exception("Could not read the stream out as bytes.", e);
        }
    }

    #endregion
}
