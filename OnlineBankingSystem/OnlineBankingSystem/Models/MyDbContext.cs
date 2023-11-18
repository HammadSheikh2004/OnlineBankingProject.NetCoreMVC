using Microsoft.EntityFrameworkCore;

namespace OnlineBankingSystem.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ChequeBook> chequeBooks { get; set; }



        

    }
}
