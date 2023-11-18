using System.ComponentModel.DataAnnotations;

namespace OnlineBankingSystem.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public string FromAccountId { get; set; }
        public string ToAccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
