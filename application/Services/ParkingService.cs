using application.Entities;

namespace application.Services;

public class ParkingService
{
  private readonly List<Vehicle> _parkedVehicles;
  private const decimal ParkingCost = 5.00m;

  public ParkingService()
  {
    _parkedVehicles = [];
  }

  public string RegisterVehicle(string licensePlate)
  {
    try
    {
      var vehicle = new Vehicle
      {
        LicensePlate = licensePlate,
        Cost = ParkingCost
      };

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

      return $"Veículo {licensePlate} removido com sucesso.\nTotal à pagar: R$ {CalculateParkingCost(vehicle):F2}";
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

  private static decimal CalculateParkingCost(Vehicle vehicle)
  {
    var parkedDuration = DateTime.Now - vehicle.EntryTime;
    var hoursParked = Math.Ceiling(parkedDuration.TotalHours);
    return vehicle.Cost * (decimal)hoursParked;
  }
}
