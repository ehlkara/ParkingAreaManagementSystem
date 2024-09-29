using Microsoft.EntityFrameworkCore;
using ParkAreaManagementSystem.Domain.Entities;
using ParkAreaManagementSystem.Infrastructure.Configurations;

namespace ParkAreaManagementSystem.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<ParkingSpot> ParkingSpots { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ParkingSpotConfiguration());
        modelBuilder.ApplyConfiguration(new VehicleConfiguration());
    }
}
