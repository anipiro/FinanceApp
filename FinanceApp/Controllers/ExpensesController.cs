 using FinanceApp.Data.Service;
 using FinanceApp.ViewModels;
 using Microsoft.AspNetCore.Mvc;

 namespace FinanceApp.Controllers;

 public class ExpensesController(IExpensesService expensesService) : Controller
 {
     public async Task<IActionResult> Index()
     {
         var expenses = await expensesService.GetAllAsync();
         return View(expenses);
     }

     public IActionResult Create() => View();

     [HttpPost]
     public async Task<IActionResult> Create(ExpenseInputModel input)
     {
         if (!ModelState.IsValid)
             return View(input);

         await expensesService.AddAsync(input);
         return RedirectToAction(nameof(Index));
     }

     public async Task<IActionResult> GetChart()
     {
         var data = await expensesService.GetChartDataAsync();
         return Json(data);
     }
 }
