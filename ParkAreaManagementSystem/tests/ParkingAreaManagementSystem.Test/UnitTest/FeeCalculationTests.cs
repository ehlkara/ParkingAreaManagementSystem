using ParkAreaManagementSystem.Domain.Entities;

namespace ParkingAreaManagementSystem.Test.UnitTest;

public class FeeCalculationTests
{
    [Fact]
    public void CalculateFee_ShouldReturnCorrectFee_ForSmallVehicle()
    {
        var parkingSpot = new ParkingSpot("A", VehicleSize.Small);
        var startTime = DateTime.Now.AddHours(-2);
        parkingSpot.ParkVehicle();

        parkingSpot.RemoveVehicle();
        var duration = parkingSpot.EndTime - startTime;
        var fee = parkingSpot.CalculateFee(duration.Value);

        Assert.Equal(10m, fee, 2);
    }

    [Fact]
    public void CalculateFee_ShouldReturnCorrectFee_ForLargeVehicle()
    {
        var parkingSpot = new ParkingSpot("B", VehicleSize.Large);
        var startTime = DateTime.Now.AddHours(-3);
        parkingSpot.ParkVehicle();

        parkingSpot.RemoveVehicle();
        var duration = parkingSpot.EndTime - startTime;
        var fee = parkingSpot.CalculateFee(duration.Value);

        Assert.Equal(45m, fee, 2);
    }
}