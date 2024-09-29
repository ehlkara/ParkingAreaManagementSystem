using ParkAreaManagementSystem.Domain.Entities;

namespace ParkAreaManagementSystem.Domain.Core.Repositories.Parking;

public interface IVehicleRepository : IGenericRepository<Vehicle>
{
    Task<Vehicle> GetByLicensePlateAsync(string licensePlate);
}
