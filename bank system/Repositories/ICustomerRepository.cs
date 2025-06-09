using bank_system.Dtos.CustomerDtos;

namespace bank_system.Repositories
{
    public interface ICustomerRepository
    {
        void createCustomer(CreateCustomerWithBranchesWithAccountsWithBankCardDto dto);
        CustomerWithBranchWithBankCardDto? getById(int id);
    }
}
