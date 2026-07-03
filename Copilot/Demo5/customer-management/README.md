Customer Management - Clean Architecture sample

Structure:

- src/CustomerManagement.Domain — domain entities and repository interfaces
- src/CustomerManagement.Application — DTOs, services, AutoMapper mapping
- src/CustomerManagement.Infrastructure — EF Core DbContext, repository implementations
- src/CustomerManagement.Api — ASP.NET Core 10 API wiring, controllers

Run (requires .NET 10 SDK):

```bash
dotnet restore
cd src/CustomerManagement.Api
dotnet run
```

Notes:

- The sample uses EF Core InMemory provider for quick testing. Replace with SQL Server by configuring `CustomerDbContext` in Program.cs and updating package references.
- To create a solution and add projects:

```bash
dotnet new sln -n CustomerManagement
dotnet sln add src/CustomerManagement.Domain/CustomerManagement.Domain.csproj
dotnet sln add src/CustomerManagement.Application/CustomerManagement.Application.csproj
dotnet sln add src/CustomerManagement.Infrastructure/CustomerManagement.Infrastructure.csproj
dotnet sln add src/CustomerManagement.Api/CustomerManagement.Api.csproj
```
