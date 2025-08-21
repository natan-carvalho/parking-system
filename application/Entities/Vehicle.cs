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
        throw new ArgumentException("License plate cannot be null or empty.");
      }
      _licensePlate = value;
    }
  }
}
