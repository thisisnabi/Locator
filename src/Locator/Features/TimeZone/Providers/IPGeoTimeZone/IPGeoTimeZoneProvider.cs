using Locator.Common;
using Locator.Features.TimeZone.Models;
using Microsoft.Extensions.Options;

namespace Locator.Features.TimeZone.Providers.IPGeoTimeZone;

public class IPGeoTimeZoneProvider(IOptions<AppSettings> options,
                                   HttpClient httpClient) : IGeoTimeZoneApi
{
    private readonly TimeZoneSettings _locationSettings = options.Value.Features.TimeZone;

    public async Task<GeoTimeZoneApiResponse> GetAsync(string ip, CancellationToken cancellationToken)
    {
        var url = $"?apiKey={_locationSettings.IPGeoTimeZoneProviderAPIKey}&ip={ip}";
        var response = await httpClient.GetFromJsonAsync<IPGeoTimeZoneResponse>(url, cancellationToken);

        if (response is null)
        {
            // TODO: Use custome exception
            throw new Exception("Null");
        }

        return new GeoTimeZoneApiResponse(response.TimeZone,
                                          response.TimeZoneOffset);
    }
}
