using Microsoft.EntityFrameworkCore;
using Rocket_Launch_Database__2_.Models;

namespace Rocket_Launch_Database__2_.Data
{
    public class RocketLaunchDbContext : DbContext
    {
        public RocketLaunchDbContext(DbContextOptions<RocketLaunchDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<LaunchSite> LaunchSites { get; set; }
        public DbSet<LaunchVehicle> LaunchVehicles { get; set; }
        public DbSet<Payload> Payloads { get; set; }
        public DbSet<RocketLaunch> RocketLaunches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Alice", Email = "alice@example.com" },
                new User { Id = 2, Name = "Bob", Email = "bob@example.com" }
            );

            modelBuilder.Entity<LaunchSite>().HasData(
                new LaunchSite { Id = 1, Name = "Site A", Location = "USA" },
                new LaunchSite { Id = 2, Name = "Site B", Location = "Russia" }
            );

            modelBuilder.Entity<LaunchVehicle>().HasData(
                new LaunchVehicle { Id = 1, Name = "Falcon 9", Manufacturer = "SpaceX" },
                new LaunchVehicle { Id = 2, Name = "Soyuz", Manufacturer = "Roscosmos" }
            );

            modelBuilder.Entity<Payload>().HasData(
                new Payload { Id = 1, Name = "Payload A", Weight = 1000, Type = "Satellite" },
                new Payload { Id = 2, Name = "Payload B", Weight = 2000, Type = "Spacecraft" }
);


            modelBuilder.Entity<RocketLaunch>().HasData(
    new RocketLaunch
    {
        Id = 1,
        LaunchDate = DateTime.Parse("2023-01-01"),
        LaunchVehicleId = 1,
        LaunchSiteId = 1,
        PayloadId = 1,
        UserId = 1,
        MissionOutcome = "Success"
    },
    new RocketLaunch
    {
        Id = 2,
        LaunchDate = DateTime.Parse("2023-02-01"),
        LaunchVehicleId = 2,
        LaunchSiteId = 2,
        PayloadId = 2,
        UserId = 2,
        MissionOutcome = "Failure"
    }
);
        }
    }
}
