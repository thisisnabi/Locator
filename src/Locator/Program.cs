using Locator.Common;
using Locator.Common.Persistence;
using Locator.Features.IpLocation;
using Locator.Features.IpLocation.Providers.IPGeoLocation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<LocationService>();


builder.Services.Configure<AppSettings>(builder.Configuration);
var settings = builder.Configuration.Get<AppSettings>();
ArgumentNullException.ThrowIfNull(settings, nameof(settings));

builder.Services.AddDbContext<LocatorDbContext>(options =>
{
    options.UseMongoDB(settings.MongoDbSetting.Host,
                       settings.MongoDbSetting.DatabaseName);
});

builder.Services.AddHttpClient<IGeoLocationApi, IPGeolocationProvider>(options => {
    options.BaseAddress = new Uri(settings.Features.IpLocation.IPGeolocationProviderBaseUrl);
}).SetHandlerLifetime(Timeout.InfiniteTimeSpan);



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
app.UseHttpsRedirection();

app.MapIpLocationFeatureEndpoints();

app.Run();
