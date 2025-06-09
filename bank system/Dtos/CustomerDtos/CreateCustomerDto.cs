using System.ComponentModel.DataAnnotations;

namespace bank_system.Dtos.CustomerDtos
{
    public class CreateCustomerDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
    }
}
