using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;

namespace Locator.Features.TimeZone.Domain;

[Collection("zones")]
public class Zone
{
    public ObjectId MyProperty { get; set; }

    public string TimeZone { get; set; } = null!;

    public int Offset { get; set; }

    public string IP { get; internal set; } = null!;
}
