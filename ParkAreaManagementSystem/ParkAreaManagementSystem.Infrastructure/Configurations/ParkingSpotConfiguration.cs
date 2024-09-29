using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkAreaManagementSystem.Domain.Entities;

namespace ParkAreaManagementSystem.Infrastructure.Configurations;

public class ParkingSpotConfiguration : IEntityTypeConfiguration<ParkingSpot>
{
    public void Configure(EntityTypeBuilder<ParkingSpot> builder)
    {
        builder.OwnsOne(p => p.Size, pSize =>
        {
            pSize.Property(v => v.Size)
                .HasColumnName("ParkingSpotSize")
                .IsRequired();
        });

        builder.Property(p => p.Zone)
            .IsRequired();

        builder.Property(p => p.IsOccupied)
            .IsRequired();
    }
}