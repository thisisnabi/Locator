using Microsoft.AspNetCore.Mvc.Testing;

namespace Locator.FunctionalTestings;

public abstract class BaseLocatorAPI 
    : IClassFixture<WebApplicationFactory<Program>>
{

    protected readonly HttpClient _httpClient;

    protected BaseLocatorAPI(WebApplicationFactory<Program> applicationFactory)
    {
        _httpClient = applicationFactory.CreateClient();
    }
}
