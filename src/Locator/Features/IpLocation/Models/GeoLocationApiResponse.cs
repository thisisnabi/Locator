namespace Locator.Features.IpLocation.Models;

public record GeoLocationApiResponse(
    double Latitude,
    double Longitude,
     string Country,
     string State,
     string City);