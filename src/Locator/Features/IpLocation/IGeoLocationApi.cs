using Locator.Features.IpLocation.Models;

namespace Locator.Features.IpLocation;

public interface IGeoLocationApi
{
    Task<GeoLocationApiResponse> GetAsync(string ip, CancellationToken cancellationToken);
}
