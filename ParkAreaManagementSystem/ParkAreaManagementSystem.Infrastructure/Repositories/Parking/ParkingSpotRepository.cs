using Microsoft.EntityFrameworkCore;
using ParkAreaManagementSystem.Domain.Core.Repositories.Parking;
using ParkAreaManagementSystem.Domain.Entities;

namespace ParkAreaManagementSystem.Infrastructure.Repositories.Parking;

public class ParkingSpotRepository : GenericRepository<ParkingSpot>, IParkingSpotRepository
{
    public ParkingSpotRepository(ApplicationDbContext context) : base(context) { }

    public async Task<ParkingSpot> FindAvailableSpotAsync(VehicleSize vehicleSize)
    {
        return await _dbSet
            .Where(s => s.VehicleSize.Size == vehicleSize.Size && !s.IsOccupied)
            .FirstOrDefaultAsync();
    }
}