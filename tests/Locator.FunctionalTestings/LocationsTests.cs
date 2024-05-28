using FluentAssertions;
using Locator.Features.IpLocation;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace Locator.FunctionalTestings;
public class LocationsTests : BaseLocatorAPI
{
    public LocationsTests(WebApplicationFactory<Program> applicationFactory)
        : base(applicationFactory)
    {

    }
  
    [Fact]
    public async Task Location_ShouldGetBadRequest_WhenSendInvalidIPAddress()
    {
        var ipAddress = "invalidData";

        var result = await _httpClient.GetAsync($"/locations/{ipAddress}");
        result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
 
        var message = await result.Content.ReadFromJsonAsync<string>();
        message.Should().Be("Invalid Ip Address.");
    }


    [Fact]
    public async Task Location_ShouldGetAddress_WhenSendValidIPAddress()
    {
        var ipAddress = "178.128.207.95";

        var result = await _httpClient.GetAsync($"/locations/{ipAddress}");
        result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

        var address = await result.Content.ReadFromJsonAsync<LocationResponse>();
        address.Should().NotBeNull();
        address!.City.Should().NotBeNull();
        address!.State.Should().NotBeNull();
        address!.Country.Should().NotBeNull();

    }
}
