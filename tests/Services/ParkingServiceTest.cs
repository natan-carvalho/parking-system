using application.Entities;
using application.Services;

namespace tests.Services;

[TestClass]
public class ParkingServiceTest
{
  private ParkingService _parkingService;
  private string _licensePlate;

  [TestInitialize]
  public void Setup()
  {
    _parkingService = new ParkingService(5.00m);
    _licensePlate = "ABC123";
  }

  [TestMethod]
  public void It_Shoud_Register_Vehicle()
  {
    _parkingService.RegisterVehicle(_licensePlate);
    var parkedVehicles = _parkingService.GetParkedVehicles();
    Assert.IsTrue(parkedVehicles.Any(v => v.LicensePlate == _licensePlate));
  }

  [TestMethod]
  public void It_Shoud_Retrun_A_List_Of_Vehicle()
  {
    var parkedVehicles = _parkingService.GetParkedVehicles();
    Assert.IsNotNull(parkedVehicles);
  }

  [TestMethod]
  public void It_Shoud_Remove_Vehicle()
  {
    _parkingService.RegisterVehicle("VehicleForRemoval");
    _parkingService.RemoveVehicle("VehicleForRemoval");
    var parkedVehicles = _parkingService.GetParkedVehicles();
    Assert.IsFalse(parkedVehicles.Contains(new Vehicle { LicensePlate = "VehicleForRemoval" }));
  }

  [TestMethod]
  public void It_Should_Throw_Exception_When_Removing_Nonexistent_Vehicle()
  {
    Assert.IsTrue(_parkingService.RemoveVehicle("NONEXISTENT123").Contains("Este veículo não foi cadastrado."));
  }

  [TestMethod]
  public void It_Should_Throw_Exception_When_LicensePlate_Is_Null_On_Remove()
  {
    Assert.IsTrue(_parkingService.RemoveVehicle(null).Contains("A placa do veículo não pode ser nula ou vazia."));
  }
}
