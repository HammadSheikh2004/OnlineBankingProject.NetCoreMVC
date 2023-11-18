using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineBankingSystem.Models;

namespace OnlineBankingSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly MyDbContext _context;
        public AdminController(MyDbContext dbContext) {
            _context = dbContext;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowRegisteredAccount() {
            var userInfo = _context.BankAccounts.OrderByDescending(Id => Id.Account_User_Id).ToList();
            return View(userInfo);
        }

        public IActionResult EditAccountNumber(int Id)
        {
            var AccNum = _context.BankAccounts.Find(Id);
            return View(AccNum);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAccountNumber(BankAccount bankAccount)
        {
            if (!ModelState.IsValid) { 
                return View(bankAccount);
            }
            else
            {
                _context.BankAccounts.Update(bankAccount);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public IActionResult ShowTransactionData()
        {
            var transactionData = _context.Transactions.OrderByDescending(Id => Id.TransactionId).ToList();
            return View(transactionData);
        }

        public IActionResult ShowChequeBook()
        {
            var chequeBookData = _context.chequeBooks.OrderByDescending(Id => Id.ChequeBook_Id).ToList();
            return View(chequeBookData);
        }

        

        
    }
}
