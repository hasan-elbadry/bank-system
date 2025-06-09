using System.ComponentModel.DataAnnotations;

namespace bank_system.Dtos.BranchDtos
{
    public class UpdateBranchWithCustomerIdDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public string Location { get; set; }
        public List<int>? CustomerIds { get; set; }
    }
}
