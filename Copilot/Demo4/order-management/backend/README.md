# Backend - OrderManagement (ASP.NET Core 10, Clean Architecture)

Project structure (skeleton):

- `OrderManagement.Domain` - domain entities and value objects
- `OrderManagement.Application` - use cases, DTOs, interfaces
- `OrderManagement.Infrastructure` - EF Core DbContext, repositories
- `OrderManagement.API` - ASP.NET Core Web API (Program.cs)

Run the API:

```bash
cd backend/src/OrderManagement.API
dotnet restore
dotnet build
dotnet run
```

Database:

- Uses SQL Server connection string in `appsettings.json` (skeleton provided)

Notes:

- This is a minimal skeleton to get started. Implement services, repositories, and DTO mappings next.
