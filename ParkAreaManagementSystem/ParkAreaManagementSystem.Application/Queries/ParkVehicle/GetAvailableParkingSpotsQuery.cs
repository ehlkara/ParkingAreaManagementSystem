using MediatR;
using ParkAreaManagementSystem.Domain.Entities;

namespace ParkAreaManagementSystem.Application.Queries.ParkVehicle;

public class GetAvailableParkingSpotsQuery : IRequest<IReadOnlyList<ParkingSpot>>
{
    public VehicleSize VehicleSize { get; set; }

    public GetAvailableParkingSpotsQuery(VehicleSize vehicleSize)
    {
        VehicleSize = vehicleSize;
    }
}
