using ParkAreaManagementSystem.Domain.Core;

namespace ParkAreaManagementSystem.Domain.Entities;

public class Vehicle : Entity, IAggregateRoot
{
    public string LicensePlate { get; private set; }
    public VehicleSize Size { get; private set; }

    private Vehicle() { }

    public Vehicle(string licensePlate, VehicleSize size)
    {
        LicensePlate = licensePlate;
        Size = size;
    }
}