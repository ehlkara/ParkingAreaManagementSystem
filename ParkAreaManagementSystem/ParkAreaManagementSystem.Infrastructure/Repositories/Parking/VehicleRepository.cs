using Microsoft.EntityFrameworkCore;
using ParkAreaManagementSystem.Domain.Core.Repositories.Parking;
using ParkAreaManagementSystem.Domain.Entities;

namespace ParkAreaManagementSystem.Infrastructure.Repositories.Parking;

public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Vehicle> GetByLicensePlateAsync(string licensePlate)
    {
        return await _dbSet.FirstOrDefaultAsync(v => v.LicensePlate == licensePlate);
    }
}