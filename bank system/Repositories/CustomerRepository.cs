using bank_system.Data;
using bank_system.Dtos.CustomerDtos;
using bank_system.Models;
using Microsoft.EntityFrameworkCore;

namespace bank_system.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void createCustomer(CreateCustomerWithBranchesWithAccountsWithBankCardDto dto)
        {
            var customer = new Customer
            {
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                BankCard = dto.BankCard !=null? new BankCard
                {
                    CardNumber = dto.BankCard.CardNumber,
                    ExpiryDate = dto.BankCard.ExpiryDate,
                } :null,
                Accounts = dto.Accounts?.Select(a => new Account
                {
                    AccountNumber = a.AccountNumber,
                    Balance = a.Balance
                }).ToList(),
                Branches = dto.Branches?.Select(b => new Branch
                {
                    Name = b.Name,
                    Location = b.Location
                }).ToList()
            };
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public CustomerWithBranchWithBankCardDto? getById(int id)
        {
            var customer = _context.Customers.Include(x=>x.BankCard).Include(x=>x.Branches).FirstOrDefault(x=>x.Id == id);
            if (customer == null)
                return null;
            return new CustomerWithBranchWithBankCardDto
            {
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                BankCard = customer.BankCard != null ? new Dtos.BankCardDtos.CreateBankCardDto
                {
                    CardNumber = customer.BankCard.CardNumber,
                    ExpiryDate = customer.BankCard.ExpiryDate

                } : null,
                Branches = customer.Branches?.Select(x => new Dtos.BranchDtos.CreateBranchDto
                {
                    Name = x.Name,
                    Location = x.Location
                }).ToList()
            };
        }
    }
}
