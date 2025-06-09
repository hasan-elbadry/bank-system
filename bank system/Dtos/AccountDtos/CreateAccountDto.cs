using System.ComponentModel.DataAnnotations;

namespace bank_system.Dtos.AccountDtos
{
    public class CreateAccountDto
    {
        [MaxLength(20)]
        public string AccountNumber { get; set; } = string.Empty; // unique
        [Range(0, double.MaxValue)]
        public decimal Balance { get; set; }
    }
}
