namespace application.Entities;

public class Vehicle
{
  private string _licensePlate;
  private decimal _cost;
  private DateTime _entryTime = DateTime.Now;

  public string LicensePlate
  {
    get => _licensePlate;
    set
    {
      Validation(value, "Favor informe um valor valido.");
      _licensePlate = value;
    }
  }

  public decimal Cost
  {
    get => _cost;
    set
    {
      Validation(value, "Favor informe um valor valido.");
      _cost = value;
    }
  }

  public DateTime EntryTime
  {
    get => _entryTime;
  }

  private static void Validation<T>(T value, string message)
  {
    if (string.IsNullOrWhiteSpace(value?.ToString()) || value.GetType() != typeof(string) && float.Parse(value?.ToString()) < 0)
    {
      throw new ArgumentNullException(nameof(value), message);
    }
  }
}
