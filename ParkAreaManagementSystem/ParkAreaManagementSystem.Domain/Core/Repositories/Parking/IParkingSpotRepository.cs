using ParkAreaManagementSystem.Domain.Entities;

namespace ParkAreaManagementSystem.Domain.Core.Repositories.Parking;

public interface IParkingSpotRepository : IGenericRepository<ParkingSpot>
{
    Task<ParkingSpot> FindAvailableSpotAsync(VehicleSize size);
}