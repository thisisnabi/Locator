using Locator.Common;
using Locator.Features.IpLocation.Models;
using Microsoft.Extensions.Options;

namespace Locator.Features.IpLocation.Providers.IPGeoLocation;

public class IPGeolocationProvider(IOptions<AppSettings> options,
                                   HttpClient httpClient) : IGeoLocationApi
{
    private readonly IpLocationSettings _locationSettings = options.Value.Features.IpLocation;

    public async Task<GeoLocationApiResponse> GetAsync(string ip, CancellationToken cancellationToken)
    {
        var url = $"?apiKey={_locationSettings.IPGeolocationProviderAPIKey}&ip={ip}";
        var response = await httpClient.GetFromJsonAsync<IPGeoLocationResponse>(url, cancellationToken);

        if (response is null)
        {
            // TODO: Use custome exception
            throw new Exception("Null");
        }

        return new GeoLocationApiResponse(response.Latitude,
                                          response.Longitude,
                                          response.Country,
                                          response.State,
                                          response.City);
    }
}
