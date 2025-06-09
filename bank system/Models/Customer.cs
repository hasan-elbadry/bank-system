using System.ComponentModel.DataAnnotations;

namespace bank_system.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        public BankCard? BankCard { get; set; }
        public List<Branch>? Branches { get; set; }
        public List<Account>? Accounts { get; set; }
    }
}
