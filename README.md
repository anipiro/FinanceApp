# FinanceApp

A small ASP.NET Core MVC app for recording personal expenses and seeing how they split across categories.

## What it does

- **Expense list.** `/Expenses` shows every expense in a table with its description, amount, category and date, newest first.
- **Add an expense.** `/Expenses/Create` is a form with a description, an amount and a category. The date is set on the server when the expense is saved.
- **Input checks.** All three fields are required and the amount must be greater than zero. If the input is invalid the form is shown again and nothing is saved.
- **Category chart.** Below the table, a Chart.js pie chart shows the total spent per category. The page fetches the totals as JSON from `/Expenses/GetChart`.

There is no editing or deleting of expenses, and no user accounts. The home page is still the default template page and the navigation bar has no link to the expenses, so open `/Expenses` directly.

## How it is built

| Part | Technology |
|------|------------|
| App framework | ASP.NET Core MVC on .NET 9 |
| Data access | Entity Framework Core 9.0.1 (`Microsoft.EntityFrameworkCore.SqlServer`) |
| Database | SQL Server |
| Front end | Razor views, Bootstrap 5.3.3, Chart.js loaded from the jsDelivr CDN |

`Controllers/ExpensesController.cs` handles the requests and depends only on `IExpensesService`. `Data/Service/ExpensesService.cs` implements that interface on top of `Data/FinanceAppContext.cs`, the EF Core `DbContext`, and does the querying, saving and per-category grouping. The `Models/Expense.cs` entity never reaches the views: the service maps it to the classes in `ViewModels/` (`ExpenseViewModel` for the list, `ExpenseInputModel` for the form, `ChartDataDto` for the chart). `Program.cs` registers the context and the service; the `Pages/Expenses` folder holds two unused placeholder files.

## Routes

| Method | Path | What it does |
|--------|------|--------------|
| GET | `/Expenses` | Lists all expenses and draws the chart. |
| GET | `/Expenses/Create` | Shows the form for a new expense. |
| POST | `/Expenses/Create` | Validates and saves the expense, then redirects to the list. |
| GET | `/Expenses/GetChart` | Returns JSON: one `{ "category", "total" }` object per category. |

## Run it locally

You need the .NET 9 SDK, a SQL Server instance (SQL Server Express is enough), and the EF Core command-line tool:

```bash
dotnet tool install --global dotnet-ef
```

1. Clone the repository and go to the project folder.

   ```bash
   git clone https://github.com/anipiro/FinanceApp.git
   cd FinanceApp/FinanceApp
   ```

2. Set the connection string. It lives in `FinanceApp/appsettings.json` under `ConnectionStrings:FinanceAppContext`. The committed value points at the author's own machine, so replace it with your server:

   ```json
   "ConnectionStrings": {
     "FinanceAppContext": "Server=YOUR_SERVER;Database=FinanceApp_data;Trusted_Connection=True;TrustServerCertificate=True"
   }
   ```

3. Create the database and the `Expenses` table.

   ```bash
   dotnet restore
   dotnet ef database update
   ```

4. Start the app.

   ```bash
   dotnet run
   ```

`dotnet run` uses the `http` launch profile and listens on `http://localhost:5111`, so the expenses are at `http://localhost:5111/Expenses`. For HTTPS on `https://localhost:7082`, use `dotnet run --launch-profile https`. In Visual Studio, open `FinanceApp.sln`, run `Update-Database` in the Package Manager Console and press F5.

If the chart stays empty, check that `/Expenses/GetChart` returns JSON and that the browser can reach the jsDelivr CDN.

Released under the MIT License; see `LICENSE`.
