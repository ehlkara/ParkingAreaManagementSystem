using ParkAreaManagementSystem.Domain.Core;
using ParkAreaManagementSystem.Domain.Entities;

namespace ParkAreaManagementSystem.Domain.Aggregates;

public class ParkingAllocation : Entity, IAggregateRoot
{
    public Vehicle Vehicle { get; private set; }
    public ParkingSpot ParkingSpot { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime? EndTime { get; private set; }

    public ParkingAllocation(Vehicle vehicle, ParkingSpot parkingSpot)
    {
        Vehicle = vehicle ?? throw new ArgumentNullException(nameof(vehicle));
        ParkingSpot = parkingSpot ?? throw new ArgumentNullException(nameof(parkingSpot));
        StartTime = DateTime.Now;

        parkingSpot.ParkVehicle();
    }

    public void RemoveVehicle()
    {
        ParkingSpot.RemoveVehicle();
        EndTime = DateTime.Now;
    }

    public decimal CalculateParkingFee()
    {
        TimeSpan duration = (EndTime ?? DateTime.Now) - StartTime;
        return ParkingSpot.CalculateFee(duration);
    }
}
