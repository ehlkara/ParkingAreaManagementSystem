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
        modelBuilder.Entity<ParkingSpot>()
     .OwnsOne(p => p.VehicleSize, s =>
     {
         s.Property(vs => vs.Size).HasColumnName("VehicleSize").IsRequired();
     });
        modelBuilder.ApplyConfiguration(new ParkingSpotConfiguration());
        modelBuilder.ApplyConfiguration(new VehicleConfiguration());
    }
}
