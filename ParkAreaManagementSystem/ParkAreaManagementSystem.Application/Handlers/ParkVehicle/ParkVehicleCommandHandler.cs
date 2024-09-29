using MediatR;
using ParkAreaManagementSystem.Application.Commands.ParkVehicle;
using ParkAreaManagementSystem.Domain.Core.Repositories.Parking;

namespace ParkAreaManagementSystem.Application.Handlers.ParkVehicle;

public class ParkVehicleCommandHandler : IRequestHandler<ParkVehicleCommand, Unit>
{
    private readonly IParkingSpotRepository _parkingSpotRepository;
    private readonly IVehicleRepository _vehicleRepository;

    public ParkVehicleCommandHandler(IParkingSpotRepository parkingSpotRepository, IVehicleRepository vehicleRepository)
    {
        _parkingSpotRepository = parkingSpotRepository;
        _vehicleRepository = vehicleRepository;
    }
    public async Task<Unit> Handle(ParkVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(request.VehicleId);
        if (vehicle == null)
            throw new InvalidOperationException("Vehicle not found.");

        var availableSpot = await _parkingSpotRepository.FindAvailableSpotAsync(request.Size);
        if (availableSpot == null)
            throw new InvalidOperationException("No available parking spot found.");

        availableSpot.ParkVehicle();
        await _parkingSpotRepository.UpdateAsync(availableSpot);

        return Unit.Value;
    }
}
