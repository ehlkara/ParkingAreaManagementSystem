using MediatR;
using ParkAreaManagementSystem.Domain.Entities;

namespace ParkAreaManagementSystem.Application.Commands.ParkVehicle;

public class ParkVehicleCommand : IRequest<Unit>
{
    public int VehicleId { get; set; }
    public string Zone { get; set; }
    public VehicleSize Size { get; set; }

    public ParkVehicleCommand(int vehicleId, string zone, VehicleSize size)
    {
        VehicleId = vehicleId;
        Zone = zone;
        Size = size;
    }
}
