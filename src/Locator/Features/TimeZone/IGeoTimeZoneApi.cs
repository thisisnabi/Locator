using Locator.Features.TimeZone.Models;
namespace Locator.Features.TimeZone;

public interface IGeoTimeZoneApi
{
    Task<GeoTimeZoneApiResponse> GetAsync(string ip, CancellationToken cancellationToken);
}
