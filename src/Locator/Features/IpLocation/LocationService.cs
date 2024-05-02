using Locator.Common.Persistence;
using Locator.Features.IpLocation.Domain;
using Microsoft.EntityFrameworkCore;

namespace Locator.Features.IpLocation;

public class LocationService(LocatorDbContext _dbContext, 
                             IGeoLocationApi _geoLocationApi)
{
    public async Task<LocationResponse> GetLocatinByIP(string ip, CancellationToken cancellationToken)
    {
        var location = await _dbContext.Locations
                                       .FirstOrDefaultAsync(x => x.IP == ip, cancellationToken);

        if (location is not null)
        {
            return (LocationResponse)location;
        }

        var newLocation = await FetchLocationFromApi(ip, cancellationToken);
        return (LocationResponse)newLocation;
    }
     
    public async Task<LocationDetailsResponse> GetLocationDetailsByIp(string ip, CancellationToken cancellationToken)
    {
        var location = await _dbContext.Locations
                                       .FirstOrDefaultAsync(x => x.IP == ip, cancellationToken);

        if (location is not null)
        {
            return (LocationDetailsResponse)location;
        }

        var newLocation = await FetchLocationFromApi(ip, cancellationToken);
        return (LocationDetailsResponse)newLocation;
    }

    private async Task<Location> FetchLocationFromApi(string ip, CancellationToken cancellationToken)
    {
        var responseLocation = await _geoLocationApi.GetAsync(ip, cancellationToken);
        var newLocation = new Location
        {
            IP = ip,
            City = responseLocation.City,
            State = responseLocation.State,
            Country = responseLocation.Country,
            Latitude = responseLocation.Latitude,
            Longitude = responseLocation.Longitude
        };

        await _dbContext.Locations.AddAsync(newLocation, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return newLocation;
    }


}

