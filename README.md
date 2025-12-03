# FinanceApp

A lightweight **Razor Pages + MVC** hybrid app for tracking personal expenses. Built with **.NET 9**, using **EF Core**, **SQL Server**, and a clean service-layer architecture. Includes basic analytics via **Chart.js**.

## 🚀 Features

* Add, list, and manage expenses
* Category-based aggregation + charts
* EF Core with SQL Server
* Service layer using `IExpensesService` / `ExpensesService`
* Works in Visual Studio 2022 or via the `dotnet` CLI

## 🛠 Requirements

* .NET 9 SDK
* Visual Studio 2022 (recommended)
* SQL Server (LocalDB or remote)
* Optional: `dotnet-ef` CLI tools

## ⚙️ Configuration

Set your connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "FinanceAppContext": "Data Source=.;Initial Catalog=FinanceApp_data;Integrated Security=True;"
}
```

## 📦 Quick Start (CLI)

1. **Restore & build**

   ```bash
   dotnet restore
   dotnet build
   ```
2. **Apply migrations**

   ```bash
   dotnet ef database update
   ```
3. **Run**

   ```bash
   dotnet run
   ```
4. Open the URL shown in console (usually `https://localhost:5001`).

## 🖥 Quick Start (Visual Studio)

1. Open the solution in Visual Studio 2022
2. Add your connection string in `appsettings.json`
3. Press **F5** to run
4. For migrations, use the Package Manager Console:

   ```
   Update-Database
   ```

## 🔧 Important Startup Note

Make sure all services are registered **before** calling `builder.Build()`:

1. `builder.Services.AddRazorPages()` / `.AddControllersWithViews()`
2. `builder.Services.AddDbContext<FinanceAppContext>(...)`
3. `builder.Services.AddScoped<IExpensesService, ExpensesService>()`
4. `var app = builder.Build();`

Calling `Build()` early makes the service collection read-only and causes startup errors.

## 📂 Project Structure

* **Program.cs** — DI setup + middleware
* **FinanceApp/Data** — EF Core models, DbContext
* **FinanceApp/Data/Service** — service interfaces + implementations
* **Views/Expenses/Index.cshtml** — expense table & Chart.js rendering

## 🐛 Troubleshooting

* **Database errors** → verify connection string + run migrations
* **Chart not showing** → check `/Expenses/GetChart` returns JSON
* **Read-only services issue** → ensure no early `builder.Build()` calls

## 🤝 Contributing

Follow `CONTRIBUTING.md` and repo `.editorconfig`.
Keep DI and service configuration in `Program.cs`.

## 📄 License

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

This project is licensed under the MIT License.


