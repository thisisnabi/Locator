using Microsoft.AspNetCore.Mvc;

namespace Locator.Features.IpLocation;

public static class Endpoints
{
    public static IEndpointRouteBuilder MapIpLocationFeatureEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/locations/{ip_address:required}",
                        (LocationService locationService,
                         [FromRoute(Name = "ip_address")] string IpAddress,
                         CancellationToken cancellationToken) =>
                        {
                            return locationService.GetLocatinByIP(IpAddress, cancellationToken);
                        });

        endpoints.MapGet("/locations/{ip_address:required}/details",
                (LocationService locationService,
                 [FromRoute(Name = "ip_address")] string IpAddress,
                 CancellationToken cancellationToken) =>
                {
                    return locationService.GetLocationDetailsByIp(IpAddress, cancellationToken);
                });

        return endpoints;
    }

}
