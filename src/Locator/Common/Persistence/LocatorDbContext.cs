using Locator.Features.IpLocation.Domain;
using Locator.Features.TimeZone.Domain;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Locator.Common.Persistence;

public class LocatorDbContext : DbContext
{
    public LocatorDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }

    public DbSet<Location> Locations { get; set; }
    public DbSet<Zone> Zones { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Location>()
                    .ToCollection("locations");

        modelBuilder.Entity<Zone>()
                    .ToCollection("zones");
    }
}
