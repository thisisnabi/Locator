using Locator.Features.IpLocation.Domain;
using Locator.Features.TimeZone.Domain;

namespace Locator.Features.TimeZone;
  
public record TimeZoneResponse(string TimeZone, int Offset)
{
    public static explicit operator TimeZoneResponse(Zone location)
        => new TimeZoneResponse(location.TimeZone, location.Offset);

};