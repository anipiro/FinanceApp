FinanceApp

A lightweight Razor Pages + MVC hybrid app for tracking personal expenses. Built with .NET 9, using EF Core, SQL Server, and a clean service-layer architecture. Includes basic analytics via Chart.js.

🚀 Features

Add, list, and manage expenses

Category-based aggregation + charts

EF Core with SQL Server

Service layer using IExpensesService / ExpensesService

Works in Visual Studio 2022 or via the dotnet CLI

🛠 Requirements

.NET 9 SDK

Visual Studio 2022 (recommended)

SQL Server (LocalDB or remote)

Optional: dotnet-ef CLI tools

⚙️ Configuration

Set your connection string in appsettings.json:

"ConnectionStrings": {
  "FinanceAppContext": "Data Source=.;Initial Catalog=FinanceApp_data;Integrated Security=True;"
}

📦 Quick Start (CLI)

Restore & build

dotnet restore
dotnet build


Apply migrations

dotnet ef database update


Run

dotnet run


Open the URL shown in console (usually https://localhost:5001).

🖥 Quick Start (Visual Studio)

Open the solution in Visual Studio 2022

Add your connection string in appsettings.json

Press F5 to run

For migrations, use the Package Manager Console:

Update-Database

🔧 Important Startup Note

Make sure all services are registered before calling builder.Build():

builder.Services.AddRazorPages() / .AddControllersWithViews()

builder.Services.AddDbContext<FinanceAppContext>(...)

builder.Services.AddScoped<IExpensesService, ExpensesService>()

var app = builder.Build();

Calling Build() early makes the service collection read-only and causes startup errors.

📂 Project Structure

Program.cs — DI setup + middleware

FinanceApp/Data — EF Core models, DbContext

FinanceApp/Data/Service — service interfaces + implementations

Views/Expenses/Index.cshtml — expense table & Chart.js rendering

🐛 Troubleshooting

Database errors → verify connection string + run migrations

Chart not showing → check /Expenses/GetChart returns JSON

Read-only services issue → ensure no early builder.Build() calls

🤝 Contributing

Follow CONTRIBUTING.md and repo .editorconfig.
Keep DI and service configuration in Program.cs.

📄 License

Specify your license (e.g., MIT), or add a LICENSE file.
