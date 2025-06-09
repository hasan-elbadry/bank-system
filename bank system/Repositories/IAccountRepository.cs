using bank_system.Dtos.AccountDtos;

namespace bank_system.Repositories
{
    public interface IAccountRepository
    {
        void CreateAccount(CreateAccountWithExsitCustomerId dto);
    }
}
