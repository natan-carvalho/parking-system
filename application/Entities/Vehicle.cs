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
      Validation(value);
      _licensePlate = value;
    }
  }

  public decimal Cost
  {
    get => _cost;
    set
    {
      Validation(value);
      _cost = value;
    }
  }

  public DateTime EntryTime
  {
    get => _entryTime;
  }

  private static void Validation<T>(T value)
  {
    if (string.IsNullOrWhiteSpace(value?.ToString()) || value.GetType() != typeof(string) && float.Parse(value?.ToString()) < 0)
    {
      throw new ArgumentNullException(nameof(value), "Favor informe um valor valido.");
    }
  }
}
