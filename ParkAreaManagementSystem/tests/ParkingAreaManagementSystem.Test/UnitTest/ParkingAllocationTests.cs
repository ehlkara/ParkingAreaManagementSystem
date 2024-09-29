using Moq;
using ParkAreaManagementSystem.Application.Commands.ParkVehicle;
using ParkAreaManagementSystem.Application.Handlers.ParkVehicle;
using ParkAreaManagementSystem.Domain.Core.Repositories.Parking;
using ParkAreaManagementSystem.Domain.Entities;

namespace ParkingAreaManagementSystem.Test.UnitTest;

public class ParkingAllocationTests
{
    private readonly Mock<IParkingSpotRepository> _parkingSpotRepositoryMock;
    private readonly Mock<IVehicleRepository> _vehicleRepositoryMock;

    public ParkingAllocationTests()
    {
        _parkingSpotRepositoryMock = new Mock<IParkingSpotRepository>();
        _vehicleRepositoryMock = new Mock<IVehicleRepository>();
    }

    [Fact]
    public async Task ParkVehicle_ShouldAssignCorrectSpot()
    {
        var vehicle = new Vehicle("34ABC123", VehicleSize.Small);
        var parkingSpot = new ParkingSpot("A", VehicleSize.Small);

        _vehicleRepositoryMock.Setup(v => v.GetByIdAsync(It.IsAny<int>()))
                              .ReturnsAsync(vehicle);

        _parkingSpotRepositoryMock.Setup(p => p.FindAvailableSpotAsync(VehicleSize.Small))
                                  .ReturnsAsync(parkingSpot);

        var command = new ParkVehicleCommand(1, "A", VehicleSize.Small);
        var handler = new ParkVehicleCommandHandler(_parkingSpotRepositoryMock.Object, _vehicleRepositoryMock.Object);

        await handler.Handle(command, new CancellationToken());

        _parkingSpotRepositoryMock.Verify(p => p.UpdateAsync(parkingSpot), Times.Once);
        Assert.True(parkingSpot.IsOccupied);
    }

    [Fact]
    public async Task ParkVehicle_ShouldThrowException_WhenNoSpotAvailable()
    {
        var vehicle = new Vehicle("34ABC123", VehicleSize.Small);

        _vehicleRepositoryMock.Setup(v => v.GetByIdAsync(It.IsAny<int>()))
                              .ReturnsAsync(vehicle);

        _parkingSpotRepositoryMock.Setup(p => p.FindAvailableSpotAsync(VehicleSize.Small))
                                  .ReturnsAsync((ParkingSpot)null);

        var command = new ParkVehicleCommand(1, "A", VehicleSize.Small);
        var handler = new ParkVehicleCommandHandler(_parkingSpotRepositoryMock.Object, _vehicleRepositoryMock.Object);

        await Assert.ThrowsAsync<InvalidOperationException>(() => handler.Handle(command, new System.Threading.CancellationToken()));
    }
}