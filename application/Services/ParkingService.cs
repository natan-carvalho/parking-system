using application.Entities;

namespace application.Services;

public class ParkingService
{
  private readonly List<Vehicle> _parkedVehicles;

  public ParkingService()
  {
    _parkedVehicles = [];
  }

  public void ParkVehicle(Vehicle vehicle)
  {
    if (vehicle == null)
    {
      throw new ArgumentNullException(nameof(vehicle), "Vehicle cannot be null.");
    }

    _parkedVehicles.Add(vehicle);
  }

  public void RemoveVehicle(Vehicle vehicle)
  {
    if (vehicle == null)
    {
      throw new ArgumentNullException(nameof(vehicle), "Vehicle cannot be null.");
    }

    _parkedVehicles.Remove(vehicle);
  }

  public List<Vehicle> GetParkedVehicles()
  {
    return [.. _parkedVehicles];
  }
}
