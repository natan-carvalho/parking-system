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
    _parkingService = new ParkingService();
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
  public void It_Shoud_Throw_Exception_When_Vehicle_Is_Null()
  {
    Assert.ThrowsException<ArgumentNullException>(() => _parkingService.RemoveVehicle(null));
  }

  [TestMethod]
  public void It_Shoud_Throw_Exception_When_LicensePlate_Is_Null()
  {
    Assert.ThrowsException<ArgumentNullException>(() => _parkingService.RegisterVehicle(null));
  }
}