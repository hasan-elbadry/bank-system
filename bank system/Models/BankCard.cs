using System.ComponentModel.DataAnnotations;

namespace bank_system.Models
{
    public class BankCard
    {
        public int Id { get; set; }
        [MaxLength(16)]
        public string CardNumber { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

    }
}
