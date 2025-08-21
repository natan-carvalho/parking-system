using application.Entities;

namespace application.Services;

public class ParkingService
{
  private readonly List<Vehicle> _parkedVehicles;

  public ParkingService()
  {
    _parkedVehicles = [];
  }

  public void RegisterVehicle(string licensePlate)
  {
    try
    {
      var vehicle = new Vehicle { LicensePlate = licensePlate };

      _parkedVehicles.Add(vehicle);
    }
    catch (Exception ex)
    {
      throw new ArgumentNullException(ex.Message);
    }
  }

  public void RemoveVehicle(string licensePlate)
  {
    var vehicle = _parkedVehicles.FirstOrDefault(v => v.LicensePlate == licensePlate);
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
