namespace application.Entities;

public class Vehicle
{
  private string _licensePlate;

  public string LicensePlate
  {
    get => _licensePlate;
    set
    {
      if (string.IsNullOrWhiteSpace(value))
      {
        throw new ArgumentNullException(nameof(LicensePlate), "Favor informe um valor valido.");
      }
      _licensePlate = value;
    }
  }
}
