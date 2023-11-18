using System.ComponentModel.DataAnnotations;

namespace OnlineBankingSystem.Models
{
    public class ChequeBook
    {
        [Key]
        public int ChequeBook_Id { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public DateTime AppliedChequeBookDate { get; set; }

        public bool submissionForm { get; set; }

    }
}
