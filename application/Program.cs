using application.Services;

bool startSystem = true;
ParkingService parkingService = new(5.00m);

while (startSystem)
{
  Console.Clear();
  Console.WriteLine("\nBem-vindo ao sistema de estacionamento.");
  Console.WriteLine("\nEscolha uma opção:");
  Console.WriteLine("1 - Cadastrar um veículo.");
  Console.WriteLine("2 - Remover um veículo.");
  Console.WriteLine("3 - Listar todos os veículos.");
  Console.WriteLine("4 - Sair.");

  var value = Console.ReadLine();

  switch (value)
  {
    case "1":
      Console.WriteLine("Informe a placa do veículo:");
      var licensePlate = Console.ReadLine();
      var registredOrThrow = parkingService.RegisterVehicle(licensePlate);
      Console.WriteLine(registredOrThrow);
      Console.WriteLine("Pressione enter para continuar.");
      Console.ReadLine();
      break;
    case "2":
      Console.WriteLine("Informe a placa do veículo:");
      var licensePlateRemove = Console.ReadLine();
      var removeOrThrow = parkingService.RemoveVehicle(licensePlateRemove);
      Console.WriteLine(removeOrThrow);
      Console.WriteLine("Pressione enter para continuar.");
      Console.ReadLine();
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
      Console.WriteLine("Pressione enter para continuar.");
      Console.ReadLine();
      break;
    case "4":
      startSystem = false;
      break;
    default:
      Console.WriteLine("Opção invalida, favor escolha uma opção valida.");
      Console.WriteLine("Pressione enter para continuar.");
      Console.ReadLine();
      break;
  }
}