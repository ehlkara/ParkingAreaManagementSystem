using MediatR;
using ParkAreaManagementSystem.Application.Queries.ParkVehicle;
using ParkAreaManagementSystem.Domain.Core.Repositories.Parking;
using ParkAreaManagementSystem.Domain.Entities;

namespace ParkAreaManagementSystem.Application.Handlers.ParkVehicle;

public class GetAvailableParkingSpotsQueryHandler : IRequestHandler<GetAvailableParkingSpotsQuery, IReadOnlyList<ParkingSpot>>
{
    private readonly IParkingSpotRepository _parkingSpotRepository;

    public GetAvailableParkingSpotsQueryHandler(IParkingSpotRepository parkingSpotRepository)
    {
        _parkingSpotRepository = parkingSpotRepository;
    }

    public async Task<IReadOnlyList<ParkingSpot>> Handle(GetAvailableParkingSpotsQuery request, CancellationToken cancellationToken)
    {
        return await _parkingSpotRepository.FindAsync(s => s.Size == request.VehicleSize && !s.IsOccupied);
    }
}
