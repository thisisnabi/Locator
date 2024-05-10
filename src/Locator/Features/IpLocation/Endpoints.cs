using Locator.Features.IpLocation.Consumers;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Locator.Features.IpLocation;

public static class Endpoints
{
    public static IEndpointRouteBuilder MapIpLocationFeatureEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var endpointGroup = endpoints.MapGroup("/locations")
                                     .WithTags("location");

        endpointGroup.MapGet("/{ip_address:required}",
                        (LocationService locationService,
                         [FromRoute(Name = "ip_address")] string IpAddress,
                         CancellationToken cancellationToken) =>
                        {
                            return locationService.GetLocatinByIP(IpAddress, cancellationToken);
                        });

        endpointGroup.MapGet("/{ip_address:required}/details",
                (LocationService locationService,
                 [FromRoute(Name = "ip_address")] string IpAddress,
                 CancellationToken cancellationToken) =>
                {
                    return locationService.GetLocationDetailsByIp(IpAddress, cancellationToken);
                });

        return endpoints;
    }

}
