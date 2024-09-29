using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkAreaManagementSystem.Domain.Entities;

namespace ParkAreaManagementSystem.Infrastructure.Configurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.OwnsOne(v => v.Size, vSize =>
        {
            vSize.Property(v => v.Size)
                .HasColumnName("VehicleSize")
                .IsRequired();
        });
    }
}