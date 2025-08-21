# Parking System

Este repositório contém uma solução para um sistema de estacionamento simples, desenvolvido em C# com .NET 8.0. A solução é composta por dois projetos principais: `application` (aplicação principal) e `tests` (testes automatizados).

---

## Projetos

### 1. [application](application/)

Projeto principal da aplicação de estacionamento.

- **Arquivo principal:** [`Program.cs`](application/Program.cs)
- **Entidades:** [`Entities/Vehicle.cs`](application/Entities/Vehicle.cs)
- **Serviços:** [`Services/ParkingService.cs`](application/Services/ParkingService.cs)
- **Dependências:** Nenhuma dependência externa além do .NET 8.0.

#### Como rodar

No terminal, execute:

```sh
dotnet run --project application
```

### 2. [tests](tests/)

Projeto de testes automatizados para a aplicação de estacionamento.

- **Tests:** [`ParkingServiceTests.cs`](tests/Services/ParkingServiceTest.cs)
- **Framework de Testes:** MSTest
- **Dependências:**
  - `Microsoft.NET.Test.Sdk`
  - `MSTest.TestAdapter`
  - `MSTest.TestFramework`
  - `coverlet.collector` (para cobertura de código)

#### Como rodar

No terminal, execute:

```sh
dotnet test tests
```

#### Dependências
- .NET 8.0 SDK
- As dependências de teste são gerenciadas via NuGet e restauradas automaticamente ao rodar os comandos acima.

#### Observações
- O projeto segue uma estrutura simples, separando entidades, serviços e testes.
- O sistema permite cadastrar, remover e listar veículos por placa.
- Os testes cobrem os principais fluxos do serviço de estacionamento.

#### Como contribuir
- Faça um fork do projeto.
- Crie uma branch para sua feature ou correção.
- Envie um pull request.
