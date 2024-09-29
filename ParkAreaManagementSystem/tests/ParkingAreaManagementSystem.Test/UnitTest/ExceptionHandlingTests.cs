using ParkAreaManagementSystem.Domain.Entities;

namespace ParkingAreaManagementSystem.Test.UnitTest;

public class ExceptionHandlingTests
{
    [Fact]
    public void RemoveVehicle_ShouldThrowException_WhenSpotIsNotOccupied()
    {
        // Arrange
        var parkingSpot = new ParkingSpot("A", VehicleSize.Small);

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => parkingSpot.RemoveVehicle());
        Assert.Equal("Parking spot is not occupied.", exception.Message);
    }

    [Fact]
    public void ParkVehicle_ShouldThrowException_WhenSpotIsOccupied()
    {
        // Arrange
        var parkingSpot = new ParkingSpot("A", VehicleSize.Small);
        parkingSpot.ParkVehicle(); // Aracın park edildiğini varsayalım

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => parkingSpot.ParkVehicle());
        Assert.Equal("Parking spot is already occupied.", exception.Message);
    }
}