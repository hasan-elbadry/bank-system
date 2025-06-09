using bank_system.Dtos.BranchDtos;

namespace bank_system.Repositories
{
    public interface IBranchRepository
    {
        void CreateBranch(CreateBranchWithCustomerDto dto);
        (bool,string) UpdateBranch(int id, UpdateBranchWithCustomerIdDto dto);
        List<BranchWithCustomerWithAccountDto> getAll();

        bool deleteBranch(int id);
    }
}