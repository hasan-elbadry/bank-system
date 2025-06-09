using bank_system.Dtos.CustomerDtos;
using bank_system.Models;
using System.ComponentModel.DataAnnotations;

namespace bank_system.Dtos.BranchDtos
{
    public class BranchWithCustomerWithAccountDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public string Location { get; set; }
        public List<CustomerWithAccountDto>? Customers { get; set; }
    }
}
