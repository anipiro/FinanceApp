using FinanceApp.ViewModels;

namespace FinanceApp.Data.Service;

public interface IExpensesService
{
    Task<IEnumerable<ExpenseViewModel>> GetAllAsync();
    Task AddAsync(ExpenseInputModel input);
    Task<IEnumerable<ChartDataDto>> GetChartDataAsync();
}
