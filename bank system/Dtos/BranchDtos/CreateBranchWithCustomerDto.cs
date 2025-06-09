using bank_system.Dtos.CustomerDtos;
using bank_system.Models;
using System.ComponentModel.DataAnnotations;

namespace bank_system.Dtos.BranchDtos
{
    public class CreateBranchWithCustomerDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public string Location { get; set; }
        public List<CreateCustomerDto>? Customers { get; set; }
    }
}
