using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace OnlineBankingSystem.Models
{
    public class BankAccount
    {
        [Key]
        public int Account_User_Id { get; set; }
        [Required]
        [DisplayName ("Name")]
        public string Account_User_Name { get; set; }
        [Required]
        [DisplayName("Email")]
        public string Account_User_Email { get; set; }
        [Required]
        [DisplayName("Address")]
        public string Account_User_Address { get; set; }
        [Required]
        [DisplayName("Country")]
        public string Account_User_Country { get; set; }
        [Required]
        [DisplayName("City")]
        public string Account_User_City { get; set; }
        [Required]
        [DisplayName("Phone Number")]
        public string Account_User_Phone_Number { get; set; }
        [Required]
        [DisplayName("Account Number")]
        public string Account_Number { get; set; }
        [Required]
        [DisplayName("Nationality")]
        public string User_Nationality { get; set; }
        [Required]
        [DisplayName("Bank Location")]
        public string BankLocation { get; set; }
        [Required]
        [DisplayName("Date")]
        public DateTime Account_Creation_Date { get; set; }
        [Required]
        [DisplayName("Account Name")]
        public string Account_Name { get; set; }
        [Required]
        [DisplayName("CNIC Number")]
        public string User_CNIC { get; set; }
        [Required]
        public decimal Balance { get; set; } = 0; 
        public string status { get; set; }


    }
}
