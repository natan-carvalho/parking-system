using application.Entities;

namespace application.Services;

public class ParkingService
{
  private readonly List<Vehicle> _parkedVehicles;

  public ParkingService()
  {
    _parkedVehicles = [];
  }

  public string RegisterVehicle(string licensePlate)
  {
    try
    {
      var vehicle = new Vehicle { LicensePlate = licensePlate };

      _parkedVehicles.Add(vehicle);
      return "";
    }
    catch (Exception ex)
    {
      return ex.Message;
    }
  }

  public string RemoveVehicle(string licensePlate)
  {
    try
    {
      var vehicle = _parkedVehicles.FirstOrDefault(v => v.LicensePlate == licensePlate);
      if (vehicle == null)
      {
        throw new ArgumentNullException(nameof(vehicle), "Este veículo não foi cadastrado.");
      }

      _parkedVehicles.Remove(vehicle);

      return $"Veículo {licensePlate} removido com sucesso.";
    }
    catch (Exception ex)
    {
      return ex.Message;
    }

  }

  public List<Vehicle> GetParkedVehicles()
  {
    return [.. _parkedVehicles];
  }
}
