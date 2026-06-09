using FinanceApp.Models;
using FinanceApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data.Service;

public class ExpensesService(FinanceAppContext context) : IExpensesService
{
    public async Task<IEnumerable<ExpenseViewModel>> GetAllAsync() =>
        await context.Expenses
            .OrderByDescending(e => e.Date)
            .Select(e => new ExpenseViewModel
            {
                Id          = e.Id,
                Description = e.Description,
                Amount      = e.Amount,
                Category    = e.Category,
                Date        = e.Date
            })
            .ToListAsync();

    public async Task AddAsync(ExpenseInputModel input)
    {
        var expense = new Expense
        {
            Description = input.Description,
            Amount      = input.Amount,
            Category    = input.Category,
            Date        = DateTime.UtcNow
        };

        context.Expenses.Add(expense);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ChartDataDto>> GetChartDataAsync() =>
        await context.Expenses
            .GroupBy(e => e.Category)
            .Select(g => new ChartDataDto
            {
                Category = g.Key,
                Total    = g.Sum(e => e.Amount)
            })
            .ToListAsync();
}
