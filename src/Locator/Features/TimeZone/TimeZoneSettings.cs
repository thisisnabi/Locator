namespace Locator.Common;

public partial class Features
{
    public TimeZoneSettings TimeZone { get; set; } = null!;

}

public class TimeZoneSettings
{
    public required string IPGeoTimeZoneProviderAPIKey { get; set; } 
    public required string IPGeoTimeZoneProviderBaseUrl { get; set; } 
}