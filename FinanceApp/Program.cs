using FinanceApp.Data;
using FinanceApp.Data.Service;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Prioritize Razor Pages (workspace indicates Razor Pages project)
        builder.Services.AddRazorPages();
        builder.Services.AddControllersWithViews();
        var connectionString = builder.Configuration.GetConnectionString("FinanceAppContext");
        builder.Services.AddDbContext<FinanceAppContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddScoped<IExpensesService, ExpensesService>();

        // Build the application AFTER all services are registered.
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseAuthorization();

        // Custom static assets mapping if available
        app.MapStaticAssets();

        // Map endpoints
        app.MapRazorPages();
        app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}
    