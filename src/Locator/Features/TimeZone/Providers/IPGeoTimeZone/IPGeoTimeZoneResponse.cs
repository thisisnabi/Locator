using System.Text.Json.Serialization;

namespace Locator.Features.TimeZone.Providers.IPGeoTimeZone;

public class IPGeoTimeZoneResponse
{
    [JsonPropertyName("timezone")]
    public string TimeZone { get; set; } = null!;

    [JsonPropertyName("timezone_offset")]
    public int TimeZoneOffset { get; set; }
}
