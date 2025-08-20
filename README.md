# Pioneers Multi-Stack Sample (ASP.NET Core, Angular, EF Core, SignalR, Spring Boot)

## Overview

This repository is a multi-project workspace showcasing a layered .NET stack (Domain, Application, Infrastructure) with a RESTful API, two MVC frontends, an Angular SSR app, and a classic ASP.NET SignalR chat sample. There is also a minimal Spring Boot stub. It is intended for learning, experimentation, and as a reference for structuring real-world solutions.

---

## Installation

### Prerequisites
- .NET SDK 8.0+
- Node.js 20+ and npm 10+
- SQL Server (LocalDB is fine) or a reachable SQL Server instance
- Visual Studio 2022 (optional, for the classic ASP.NET SignalR sample) or IIS Express

### 1) Restore .NET dependencies

```powershell
dotnet restore "Pioneers1/Pioneers1.sln"
```

### 2) Configure database connection
- API connection string is read from: `pioneers1-APII/appsettings.json`
- Default is LocalDB:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=PioneersDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

Update the value if you use a different SQL Server.

### 3) Create/update the database (EF Core Migrations)

Migrations live in `Pioneers.Infrastructure`. Apply them targeting the API as startup project:

```powershell
dotnet tool install -g dotnet-ef
dotnet ef database update --project "Pioneers.Infrastructure" --startup-project "pioneers1-APII"
```

### 4) Install Angular dependencies

```powershell
cd "Pioneers1/pioneers1.web.angular"
npm install
```

---

## Running the apps

### API (ASP.NET Core Web API)
Project: `pioneers1-APII`

```powershell
dotnet run --project "pioneers1-APII"
```

- Swagger UI (Development): `http://localhost:5130/swagger`
- CORS policy allows the Angular dev server (`http://localhost:4200`) and an additional origin (`https://localhost:5002`). Adjust in `pioneers1-APII/Program.cs` if needed.

### Angular (SSR-capable)
Project: `Pioneers1/pioneers1.web.angular`

Dev server:
```powershell
cd "Pioneers1/pioneers1.web.angular"
npm start
```
Open `http://localhost:4200/`.

SSR preview (optional, after build):
```powershell
npm run build
npm run serve:ssr:pioneers1.web.angular
```

Proxy configuration (adjust target to match your API port): `Pioneers1/pioneers1.web.angular/proxy.conf.json`

```json
{
  "/api": {
    "target": "https://localhost:7296", // e.g. API HTTPS port
    "secure": false,
    "changeOrigin": true,
    "logLevel": "debug"
  }
}
```

### MVC Front-Ends (ASP.NET Core MVC)

- Project: `Pioneers1`
  ```powershell
  dotnet run --project "Pioneers1"
  ```
  Dev URL (launch profile): `http://localhost:5195`

- Project: `Pioneers1.Web.Mvc`
  ```powershell
  dotnet run --project "Pioneers1.Web.Mvc"
  ```
  Dev URL (launch profile): `http://localhost:5260`

### SignalR Chat (classic ASP.NET MVC 5)
Project: `SignalRChat/SignalRChat`

- Open in Visual Studio and run with IIS Express, or configure an IIS site.
- Uses classic SignalR 2.x and OWIN startup in `Startup.cs` (`app.MapSignalR();`).

### Spring Boot Stub (Java)

There is a minimal Spring Boot entry point at `src/main/java/com/test/demo/DemoApplication.java`. Build tooling files (Maven/Gradle) are not included; treat this as a placeholder.

---

## Usage (API examples)

Base URL (dev): `http://localhost:5130`

Entities: Countries, Cities, Customers

```bash
# List
curl http://localhost:5130/api/countries

# Create
curl -X POST http://localhost:5130/api/countries \
  -H "Content-Type: application/json" \
  -d '{"name":"Germany"}'

# Get by id
curl http://localhost:5130/api/countries/1

# Update
curl -X PUT http://localhost:5130/api/countries/1 \
  -H "Content-Type: application/json" \
  -d '{"id":1, "name":"Deutschland"}'

# Delete
curl -X DELETE http://localhost:5130/api/countries/1
```

Validations are enforced using FluentValidation; you will get 400 responses for invalid payloads (e.g., missing or oversized fields).

---

## Project Structure

Top-level notable folders:
- `Pioneers.Domain`: Entities and repository abstractions
- `Pioneers.Application`: DTOs, AutoMapper profiles, FluentValidation rules
- `Pioneers.Infrastructure`: EF Core `DbContext`, generic repository, services, and migrations
- `pioneers1-APII`: ASP.NET Core Web API (Swagger, CORS, DI wiring)
- `Pioneers1` and `Pioneers1.Web.Mvc`: ASP.NET Core MVC apps
- `Pioneers1/pioneers1.web.angular`: Angular 20 app (SSR ready)
- `SignalRChat/SignalRChat`: Classic ASP.NET MVC 5 + SignalR sample
- `src/main/java/...`: Spring Boot stub

Key files:
- `Pioneers.Infrastructure/PioneersDbContext.cs`: EF Core model configuration
- `Pioneers.Infrastructure/Repositories/GenericRepository.cs`: basic CRUD repository
- `Pioneers.Infrastructure/Services/*Service.cs`: domain services for CRUD coordination
- `Pioneers.Application/Mapping/Profiles.cs`: AutoMapper configuration
- `pioneers1-APII/Program.cs`: API startup, DI, Swagger, CORS
- `Pioneers1/pioneers1.web.angular/angular.json`: Angular build/serve config

---

## Features
- Clean, layered architecture (Domain → Application → Infrastructure → API/UI)
- RESTful CRUD for Countries, Cities, Customers
- AutoMapper-based mapping between entities and DTOs
- FluentValidation for request validation
- EF Core (SQL Server) with migrations and strong relational modeling
- Swagger/OpenAPI for API exploration
- Angular 20 app with SSR capability and dev proxy support
- Classic ASP.NET MVC 5 SignalR chat sample

---

## Technologies
- .NET 8, ASP.NET Core
- Entity Framework Core 9 (SqlServer, Tools)
- AutoMapper 12
- FluentValidation 11/12
- Swashbuckle (Swagger) 6.4
- Angular 20, RxJS 7, TypeScript 5
- Classic ASP.NET MVC 5, SignalR 2.x, OWIN
- Spring Boot (stub)

---

## Configuration & Notes
- Connection string: `pioneers1-APII/appsettings.json` → `ConnectionStrings:DefaultConnection`
- CORS: Adjust allowed origins in `pioneers1-APII/Program.cs` policy `AllowFrontends`
- Angular proxy: `Pioneers1/pioneers1.web.angular/proxy.conf.json` → set `target` to the API URL you run
- Ports (from launch settings; may differ on your machine):
  - API: `http://localhost:5130` (`https://localhost:7296`)
  - MVC `Pioneers1`: `http://localhost:5195` (`https://localhost:7045`)
  - MVC `Pioneers1.Web.Mvc`: `http://localhost:5260` (`https://localhost:7247`)
  - Angular dev: `http://localhost:4200`

---

## Contributing
1. Fork the repo and create a feature branch.
2. Ensure builds pass and code is formatted.
3. Add/adjust tests or sample requests if applicable.
4. Open a pull request with a concise description of the change.

---

## License

No license file is currently included. If you plan to publish or reuse this work, add a suitable license (e.g., MIT) at the repository root.
by Huda Maher
