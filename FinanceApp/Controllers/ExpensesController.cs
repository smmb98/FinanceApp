using FinanceApp.Data;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Controllers {
    public class ExpensesController : Controller {
        private readonly FinanceAppContext _context;
        public ExpensesController(FinanceAppContext context) {
            _context = context;
        }
        public IActionResult Index() {
            List<Expense> expenses = _context.Expenses.ToList();
            return View(expenses);
        }
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Expense expense) {
            if (ModelState.IsValid) {
                _context.Expenses.Add(expense);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expense);
        }

    }
}
