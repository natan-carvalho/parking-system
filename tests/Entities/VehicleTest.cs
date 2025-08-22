
using application.Entities;

namespace tests.Entities;

[TestClass]
public class VehicleTest
{
  private Vehicle _vehicle;
  private string _licensePlate = "ABC123";

  [TestInitialize]
  public void Setup()
  {
    _vehicle = new();
  }

  [TestMethod]
  public void It_Shoud_Create_Vehicle()
  {
    _vehicle.LicensePlate = _licensePlate;
    Assert.AreEqual(_licensePlate, _vehicle.LicensePlate);
  }

  [TestMethod]
  public void It_Shoud_Throw_Exception_When_LicensePlate_Is_Null()
  {
    var ex = Assert.ThrowsException<ArgumentNullException>(() => _vehicle.LicensePlate = null);
    StringAssert.Contains(ex.Message, "License plate cannot be null or empty.");
  }
}
