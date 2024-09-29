using ParkAreaManagementSystem.Domain.Core;

namespace ParkAreaManagementSystem.Domain.Entities;

public class VehicleSize : ValueObject
{
    public static VehicleSize Small => new VehicleSize("Small");
    public static VehicleSize Medium => new VehicleSize("Medium");
    public static VehicleSize Large => new VehicleSize("Large");

    public string Size { get; private set; }

    public VehicleSize(string size)
    {
        Size = size;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Size;
    }
}