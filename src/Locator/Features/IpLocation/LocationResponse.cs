using Locator.Features.IpLocation.Domain;

namespace Locator.Features.IpLocation;

public record LocationResponse(string Country, string State, string City)
{
    public static explicit operator LocationResponse(Location location)
        =>  new LocationResponse(location.Country, location.State, location.City);

};