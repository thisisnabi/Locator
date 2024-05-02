using Locator.Common.Persistence;
using Locator.Features.TimeZone.Domain;
using Microsoft.EntityFrameworkCore;

namespace Locator.Features.TimeZone;

public class TimeZoneService(LocatorDbContext _dbContext,
                             IGeoTimeZoneApi _geoLocationApi)
{

    public async Task<TimeZoneResponse> GetLocatinByIP(string ip, CancellationToken cancellationToken)
    {
        var zone = await _dbContext.Zones
                                   .FirstOrDefaultAsync(x => x.IP == ip, cancellationToken);

        if (zone is not null)
        {
            return (TimeZoneResponse)zone;
        }

        var response = await _geoLocationApi.GetAsync(ip, cancellationToken);
        var newZone = new Zone
        {
            IP = ip,
            TimeZone = response.TimeZone,
            Offset = response.TimeZoneOffset,
        };

        await _dbContext.Zones.AddAsync(newZone, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return (TimeZoneResponse)newZone;
    }
}
