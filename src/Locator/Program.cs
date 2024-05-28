using Locator;
using Locator.Common;
using Locator.Common.Persistence;
using Locator.Features.IpLocation;
using Locator.Features.IpLocation.Providers.IPGeoLocation;
using Locator.Features.TimeZone;
using Locator.Features.TimeZone.Providers.IPGeoTimeZone;
using MassTransit;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<TimeZoneService>();


builder.Services.Configure<AppSettings>(builder.Configuration);
var settings = builder.Configuration.Get<AppSettings>();
ArgumentNullException.ThrowIfNull(settings, nameof(settings));

builder.Services.AddDbContext<LocatorDbContext>(options =>
{
    options.UseMongoDB(settings.MongoDbSetting.Host,
                       settings.MongoDbSetting.DatabaseName);
});

builder.Services.AddHttpClient<IGeoLocationApi, IPGeolocationProvider>(options =>
{
    options.BaseAddress = new Uri(settings.Features.IpLocation.IPGeolocationProviderBaseUrl);
}).SetHandlerLifetime(Timeout.InfiniteTimeSpan);

builder.Services.AddHttpClient<IGeoTimeZoneApi, IPGeoTimeZoneProvider>(options =>
{
    options.BaseAddress = new Uri(settings.Features.TimeZone.IPGeoTimeZoneProviderBaseUrl);
}).SetHandlerLifetime(Timeout.InfiniteTimeSpan);

builder.Services.AddMassTransit(options =>
{
    options.AddConsumers(typeof(IAssemblyMarker).Assembly);

    options.UsingRabbitMq((context, cfg) =>
    {
        cfg.UseRawJsonDeserializer();

        cfg.Host(settings.RabbitMqConfigurations.Host,
            hostConfig =>
            {
                hostConfig.Username(settings.RabbitMqConfigurations.Username);
                hostConfig.Password(settings.RabbitMqConfigurations.Password);
            });

        cfg.ConfigureEndpoints(context);
    });

});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapIpLocationFeatureEndpoints();
app.MapTimeZoneFeatureEndpoints();

app.Run();

public partial class Program { }