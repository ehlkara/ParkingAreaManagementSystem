namespace ParkAreaManagementSystem.Application.Commands.ParkVehicle;

public class RemoveVehicleCommand
{
    public int ParkingSpotId { get; set; }

    public RemoveVehicleCommand(int parkingSpotId)
    {
        ParkingSpotId = parkingSpotId;
    }
}