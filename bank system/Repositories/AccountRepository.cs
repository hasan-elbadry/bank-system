using bank_system.Data;
using bank_system.Dtos.AccountDtos;
using bank_system.Models;

namespace bank_system.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateAccount(CreateAccountWithExsitCustomerId dto)
        {
            var account = new Account
            {
                AccountNumber = dto.AccountNumber,
                Balance = dto.Balance,
                CustomerId = dto.CustomerId
            };
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
    }
}
