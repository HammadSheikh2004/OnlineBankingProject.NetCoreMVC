using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBankingSystem.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace OnlineBankingSystem.Controllers
{
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }

    public class BankingController : Controller
    {
        private readonly MyDbContext _dbContext;

        public BankingController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult OurServices()
        {
            return View();
        }

        //Codding For Create Bank Account

        [Authorize(Roles = "User")]
        [Route("Banking/CreateBankAccount")]
        [HttpGet]
        public IActionResult CreateBankAccount()
        {
            ViewBag.Name = HttpContext.Session.GetString("userName");
            ViewBag.Email = HttpContext.Session.GetString("userEmail");
            return View();
        }

        [Authorize(Roles = "User")]
        [Route("Banking/CreateBankAccount")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateBankAccount(BankAccount bankAccount)
        {
            if (!ModelState.IsValid)
            {
                return View(bankAccount);
            }
            else
            {
                bankAccount.Account_Creation_Date = DateTime.Now;
                _dbContext.BankAccounts.Add(bankAccount);
                _dbContext.SaveChanges();
                return RedirectToAction("UserDashboard");
            }
        }

        //Codding For User Dashboard
        [Authorize (Roles = "User")]
        [Route ("Banking/UserDashboard")]
        public IActionResult UserDashboard()
        {
            ViewBag.Name = HttpContext.Session.GetString("userName");
            return View();
        }

        //Codding For AccountDetails
        [Authorize(Roles = "User")]
        [Route("Banking/AccountDetails")]
        public IActionResult AccountDetails()
        {
            string userEmail = HttpContext.Session.GetString("userEmail");
            BankAccount userBankAccount = _dbContext.BankAccounts.FirstOrDefault(account => account.Account_User_Email == userEmail);
            HttpContext.Session.SetObject("userBankAccount", userBankAccount);
            return View(userBankAccount);
        }

        //Codding For Transfer Money
        [Authorize(Roles = "User")]
        [Route("Banking/TransferMoney")]
        public IActionResult TransferMoney(string fromAccountId, string toAccountId, decimal amount, string accountNumber)
        {
            var userData = _dbContext.BankAccounts.Where(userAccount => userAccount.Account_Number == accountNumber).FirstOrDefault();

            var sourceAccount = _dbContext.BankAccounts.Where(FromAccount => FromAccount.Account_Number == fromAccountId).FirstOrDefault();
            var destinationAccount = _dbContext.BankAccounts.Where(ToAccount => ToAccount.Account_Number == toAccountId).FirstOrDefault();

            if (sourceAccount != null && destinationAccount != null)
            {
                if (sourceAccount.Balance >= amount)
                {
                    sourceAccount.Balance -= amount;
                    destinationAccount.Balance += amount;

                    var transaction = new Transaction
                    {
                        FromAccountId = fromAccountId,
                        ToAccountId = toAccountId,
                        Amount = amount,
                        TransactionDate = DateTime.Now,
                    };

                    _dbContext.Transactions.Add(transaction);
                    _dbContext.SaveChanges();

                    return View();
                }
            }

            return View(userData);
        }


        //Codding For Applying Cheque Book
        [Authorize(Roles = "User")]
        [Route("Banking/ApplyingChequeBook")]
        [HttpGet]
        public IActionResult ApplyingChequeBook()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        [Route("Banking/ApplyingChequeBook")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ApplyingChequeBook(ChequeBook chequeBook)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                chequeBook.AppliedChequeBookDate = DateTime.Now;
                _dbContext.chequeBooks.Add(chequeBook);
                _dbContext.SaveChanges();
                return View();
            }   
        }




    }




}
