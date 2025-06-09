using bank_system.Data;
using bank_system.Dtos.BranchDtos;
using Microsoft.EntityFrameworkCore;

namespace bank_system.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly ApplicationDbContext _context;

        public BranchRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateBranch(CreateBranchWithCustomerDto dto)
        {
            var branch = new Models.Branch
            {
                Name = dto.Name,
                Location = dto.Location,
                Customers = dto.Customers?.Select(x=>new Models.Customer
                {
                    Name = x.Name,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                }).ToList()
            };

            _context.Add(branch);
            _context.SaveChanges();
        }

        public bool deleteBranch(int id)
        {
            try
            {
                var branch = _context.Branches.FirstOrDefault(x => x.Id == id);
                if (branch == null)
                    return false;
                _context.Branches.Remove(branch);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
      

        }

        public List<BranchWithCustomerWithAccountDto> getAll()
        {
            return _context.Branches.Select(x=>new BranchWithCustomerWithAccountDto
            {
                Name = x.Name,
                Location = x.Location,
                Customers = x.Customers!=null? x.Customers.Select(x=>new Dtos.CustomerDtos.CustomerWithAccountDto
                {
                    Name = x.Name,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Accounts = x.Accounts!=null? x.Accounts.Select(x=>new Dtos.AccountDtos.CreateAccountDto
                    {
                        Balance = x.Balance,
                        AccountNumber = x.AccountNumber
                    }).ToList():null
                }).ToList():null
            }).ToList();
        }

        public (bool,string) UpdateBranch(int id, UpdateBranchWithCustomerIdDto dto)
        {
            var branch = _context.Branches.Include(x=>x.Customers).FirstOrDefault(x => x.Id == id);
            if (branch == null)
                return (false,"banch not found");
     
            if(dto.CustomerIds != null)
            {
                if (!(_context.Customers.Any(x => dto.CustomerIds.Contains(x.Id))))
                {
                    return (false, "customers ids not correct and not in database");
                }
                branch.Customers = [];

                var customers = _context.Customers
                    .Where(x => dto.CustomerIds.Contains(x.Id))
                    .ToList();

                branch.Customers.AddRange(customers);
            }
            branch.Name = dto.Name;
            branch.Location = dto.Location;
            _context.SaveChanges();
            return (true, "data added success");

        }
    }
}
