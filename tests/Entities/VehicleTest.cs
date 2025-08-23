
using application.Entities;

namespace tests.Entities;

[TestClass]
public class VehicleTest
{
  private Vehicle _vehicle;
  private string _licensePlate = "ABC123";
  private decimal _cost = 10m;

  [TestInitialize]
  public void Setup()
  {
    _vehicle = new();
  }

  [TestMethod]
  public void It_Shoud_Create_Vehicle()
  {
    _vehicle.LicensePlate = _licensePlate;
    _vehicle.Cost = _cost;
    Assert.AreEqual(_licensePlate, _vehicle.LicensePlate);
    Assert.AreEqual(_cost, _vehicle.Cost);
  }

  [TestMethod]
  public void It_Shoud_Throw_Exception_When_LicensePlate_Is_Null()
  {
    var ex = Assert.ThrowsException<ArgumentNullException>(() => _vehicle.LicensePlate = null);
    StringAssert.Contains(ex.Message, "Favor informe um valor valido.");
  }
}
