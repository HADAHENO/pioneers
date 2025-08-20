# Pioneers1 Web Angular + .NET API

## Overview
This project demonstrates a full-stack system using *.NET Core (Onion Architecture)* for the backend and *Angular* for the frontend.  
It includes CRUD operations for *Countries, **Cities, and **Customers*.

---

## Project Structure

### Backend (.NET Core / C#)
- *Domain Layer*: Contains entities and core logic (Country, City, Customer).
- *Application Layer*: Business services and DTOs.
- *Infrastructure Layer*: Handles database persistence (Entity Framework Core).
- *API Layer*: Exposes REST endpoints at /api/*.

*API Endpoints*:
- /api/Countries → CRUD for countries
- /api/Cities → CRUD for cities
- /api/Customers → CRUD for customers

---

### Frontend (Angular)
- Folder: pioneers1.web.angular/src/app
- *Components*:
  - countries → DataGrid for Countries
  - cities → DataGrid for Cities (with Country lookup)
  - customers → DataGrid for Customers (with City and Country lookup)
- *Services*:
  - api.service.ts → Handles CRUD requests using Axios

*Environment*:
- src/environments/environment.ts
```ts
export const environment = {
  production: false,
  apiBase: 'https://localhost:7296'
};

> Make sure the port matches your running .NET API.



Styles & Scripts (angular.json):

"styles": [
  "node_modules/devextreme/dist/css/dx.light.css",
  "src/styles.css"
],
"scripts": [
  "node_modules/devextreme/dist/js/dx.all.js"
]


---

Installation

Backend

1. Open solution in Visual Studio


2. Restore NuGet packages


3. Run migrations (if using EF Core)


4. Start API project → default URL: https://localhost:7296



Frontend

1. Navigate to Angular folder:



cd D:\demo\Pioneers1\pioneers1.web.angular

2. Install dependencies:



npm install

3. Run Angular app (if 4200 busy, pick another port):



ng serve --port 4300

4. Open in browser:



http://localhost:4300


---

Notes

All CRUD operations in Angular connect directly to the .NET API.

If DevExtreme DataGrid fails, make sure devextreme and devextreme-angular are installed.

Ensure all service files (api.service.ts, test.service.ts) exist and import paths are correct.

Template HTML should be in separate .html files (templateUrl) instead of inline strings to avoid Angular compiler errors.



---

Fixing Common Errors

1. Port 4200 already in use → Use --port <new-port>


2. Cannot find module / missing services → Check file exists and import path is correct


3. Template errors → Move HTML into .html files instead of inline in TypeScript


4. Axios or DevExtreme not found → Run npm install axios devextreme devextreme-angular




---

Developed by Huda
