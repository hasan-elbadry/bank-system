using System.ComponentModel.DataAnnotations;

namespace bank_system.Dtos.AccountDtos
{
    public class CreateAccountWithExsitCustomerId
    {
        [MaxLength(20)]
        public string AccountNumber { get; set; } = string.Empty; 
        [Range(0, double.MaxValue)]
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
    }
}
