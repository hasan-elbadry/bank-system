using System.ComponentModel.DataAnnotations;

namespace bank_system.Dtos.BranchDtos
{
    public class CreateBranchDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
