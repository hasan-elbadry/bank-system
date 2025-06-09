using bank_system.Dtos.AccountDtos;
using bank_system.Dtos.BankCardDtos;
using bank_system.Dtos.BranchDtos;
using bank_system.Models;
using System.ComponentModel.DataAnnotations;

namespace bank_system.Dtos.CustomerDtos
{
    public class CreateCustomerWithBranchesWithAccountsWithBankCardDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        public CreateBankCardDto? BankCard { get; set; }
        public List<CreateBranchDto>? Branches { get; set; }
        public List<CreateAccountDto>? Accounts { get; set; }
    }
}
