using application.Services;

bool startSystem = true;
ParkingService parkingService = new(5.00m);

static void InitProgram()
{
  Console.Clear();
  Console.WriteLine("\nBem-vindo ao sistema de estacionamento.");
  Console.WriteLine("\nEscolha uma opção:");
  Console.WriteLine("1 - Cadastrar um veículo.");
  Console.WriteLine("2 - Remover um veículo.");
  Console.WriteLine("3 - Listar todos os veículos.");
  Console.WriteLine("4 - Sair.");
}

static void WriteDefault(string message)
{
  Console.WriteLine(message);
  Console.WriteLine("Pressione enter para continuar.");
  Console.ReadLine();
}

while (startSystem)
{
  InitProgram();

  var value = Console.ReadLine();

  switch (value)
  {
    case "1":
      Console.WriteLine("Informe a placa do veículo:");
      var licensePlate = Console.ReadLine();
      var registredOrThrow = parkingService.RegisterVehicle(licensePlate);
      WriteDefault(registredOrThrow);
      break;
    case "2":
      Console.WriteLine("Informe a placa do veículo:");
      var licensePlateRemove = Console.ReadLine();
      var removeOrThrow = parkingService.RemoveVehicle(licensePlateRemove);
      WriteDefault(removeOrThrow);
      break;
    case "3":
      var vehicles = parkingService.GetParkedVehicles();
      Console.WriteLine("Placa:");
      int index = 0;
      vehicles.ForEach(vehicle =>
      {
        Console.WriteLine($"{index} - {vehicle.LicensePlate}");
        index++;
      });
      WriteDefault("");
      break;
    case "4":
      startSystem = false;
      break;
    default:
      WriteDefault("Opção invalida, favor escolha uma opção valida.");
      break;
  }
}