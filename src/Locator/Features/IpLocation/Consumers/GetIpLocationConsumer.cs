using MassTransit;
namespace Locator.Features.IpLocation.Consumers;

public class GetIpLocationConsumer(
    LocationService locationService,
    IPublishEndpoint publisher) : IConsumer<GetIpLocationMessage>
{
    public async Task Consume(ConsumeContext<GetIpLocationMessage> context)
    {
        var location = await locationService.GetLocatinByIP(context.Message.Ip, context.CancellationToken);
    }
}
