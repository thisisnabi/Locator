using System.Text.Json.Serialization;

namespace Locator.Features.IpLocation.Providers.IPGeoLocation;

public class IPGeoLocationResponse
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("continent_name")]
    public required string ContinentName { get; set; }

    [JsonPropertyName("country_name")]
    public required string Country { get; set; }

    [JsonPropertyName("state_prov")]
    public required string State { get; set; }

    [JsonPropertyName("city")]
    public required string City { get; set; }

    [JsonPropertyName("calling_code")]
    public required string CallingCode { get; set; }
}
