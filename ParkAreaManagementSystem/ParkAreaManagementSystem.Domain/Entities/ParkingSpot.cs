using ParkAreaManagementSystem.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace ParkAreaManagementSystem.Domain.Entities;

public class ParkingSpot : Entity, IAggregateRoot
{
    public string Zone { get; private set; }
    public VehicleSize VehicleSize { get; private set; }
    public bool IsOccupied { get; private set; }
    public DateTime? StartTime { get; private set; }
    public DateTime? EndTime { get; private set; }

    [Timestamp]
    public byte[] RowVersion { get; private set; } = new byte[8];

    private ParkingSpot() { }

    public ParkingSpot(string zone, VehicleSize size)
    {
        Zone = zone;
        VehicleSize = size;
        IsOccupied = false;
    }

    public void ParkVehicle()
    {
        if (IsOccupied)
            throw new InvalidOperationException("Parking spot is already occupied.");

        IsOccupied = true;
        StartTime = DateTime.Now;
    }

    public void RemoveVehicle()
    {
        if (!IsOccupied)
            throw new InvalidOperationException("Parking spot is not occupied.");

        IsOccupied = false;
        EndTime = DateTime.Now;
    }

    public decimal CalculateFee(TimeSpan duration)
    {
        decimal baseRate = VehicleSize.Size switch
        {
            "Small" => 5m,
            "Medium" => 10m,
            "Large" => 15m,
            _ => 5m
        };

        return baseRate * (decimal)duration.TotalHours;
    }
}