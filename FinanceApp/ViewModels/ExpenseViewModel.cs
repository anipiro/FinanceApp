namespace FinanceApp.ViewModels;

public sealed class ExpenseViewModel
{
    public int Id { get; init; }
    public string Description { get; init; } = string.Empty;
    public decimal Amount { get; init; }
    public string Category { get; init; } = string.Empty;
    public DateTime Date { get; init; }
}
