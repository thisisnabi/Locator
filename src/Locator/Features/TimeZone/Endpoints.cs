using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Locator.Features.TimeZone;

public static class Endpoints
{
    public static IEndpointRouteBuilder MapTimeZoneFeatureEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var endpointGroup = endpoints.MapGroup("/timezone")
                                     .WithTags("timezone");

        endpointGroup.MapGet("/{ip_address:required}",
                        (TimeZoneService timezoneService,
                         [FromRoute(Name = "ip_address")] string IpAddress,
                         CancellationToken cancellationToken) =>
                        {
                            return timezoneService.GetTimeZoneByIP(IpAddress, cancellationToken);
                        });
 
        return endpoints;
    }

}
