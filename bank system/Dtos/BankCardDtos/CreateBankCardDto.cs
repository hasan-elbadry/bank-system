using System.ComponentModel.DataAnnotations;

namespace bank_system.Dtos.BankCardDtos
{
    public class CreateBankCardDto
    {
        [MaxLength(16)]
        public string CardNumber { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
    }
}
