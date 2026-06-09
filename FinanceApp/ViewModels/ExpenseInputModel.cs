using System.ComponentModel.DataAnnotations;

namespace FinanceApp.ViewModels;

public sealed class ExpenseInputModel
{
    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount needs to be higher than 0")]
    public decimal Amount { get; set; }

    [Required]
    public string Category { get; set; } = string.Empty;
}
