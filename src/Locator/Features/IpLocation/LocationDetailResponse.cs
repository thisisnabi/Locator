using Locator.Features.IpLocation.Domain;

namespace Locator.Features.IpLocation;

public record LocationDetailsResponse(string IP, double Latitude, double Longitude, string Country, string State, string City)
{
    public static explicit operator LocationDetailsResponse(Location location)
    => new LocationDetailsResponse(location.IP,location.Latitude, location.Longitude, location.Country, location.State, location.City);

}
