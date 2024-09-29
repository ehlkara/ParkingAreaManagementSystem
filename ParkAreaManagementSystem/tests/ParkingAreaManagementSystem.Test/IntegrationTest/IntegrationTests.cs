using Microsoft.EntityFrameworkCore;
using ParkAreaManagementSystem.Domain.Entities;
using ParkAreaManagementSystem.Infrastructure;
using ParkAreaManagementSystem.Infrastructure.Repositories.Parking;

namespace ParkingAreaManagementSystem.Test.IntegrationTest;

public class IntegrationTests
{
    private readonly ApplicationDbContext _context;
    private readonly ParkingSpotRepository _parkingSpotRepository;

    public IntegrationTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "TestDb")
           .EnableSensitiveDataLogging()
           .Options;

        _context = new ApplicationDbContext(options);
        _parkingSpotRepository = new ParkingSpotRepository(_context);
    }

    [Fact]
    public async Task ShouldFindAvailableSpot_AndParkVehicle()
    {
        var parkingSpot = new ParkingSpot("A", VehicleSize.Small);
        await _parkingSpotRepository.AddAsync(parkingSpot);

        var foundSpot = await _parkingSpotRepository.FindAvailableSpotAsync(VehicleSize.Small);

        Assert.NotNull(foundSpot);
        Assert.False(foundSpot.IsOccupied);

        foundSpot.ParkVehicle();
        await _parkingSpotRepository.UpdateAsync(foundSpot);

        Assert.True(foundSpot.IsOccupied);
    }
}
