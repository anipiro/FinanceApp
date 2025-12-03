using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data
{
    public class FinanceAppContext : DbContext
    {
        public FinanceAppContext(DbContextOptions<FinanceAppContext> options)
            : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Prevent silent truncation by specifying precision/scale for decimal 'Amount'
            modelBuilder.Entity<Expense>(entity =>
            {
                entity.Property(e => e.Amount).HasPrecision(18, 2);
            });
        }
    }
}
