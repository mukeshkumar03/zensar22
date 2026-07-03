# Order Management - Project Skeleton

This workspace contains a skeleton for an Order Management System built with:

- Backend: ASP.NET Core 10 (Clean Architecture)
- Frontend: Angular (placeholder)
- Database: SQL Server

Modules included: Orders, Customers, Payments

Quick start (backend):

1. Install .NET 10 SDK: https://dotnet.microsoft.com
2. From `backend/src/OrderManagement.API` run:

```bash
dotnet restore
dotnet build
dotnet run
```

Quick start (frontend):

- This folder contains a placeholder. To scaffold an Angular app run:

```bash
cd frontend
npx @angular/cli new frontend-app
```

Next steps:

- Implement application services
- Scaffold Entity Framework migrations and SQL Server connection
- Add CI/CD and Docker configuration
