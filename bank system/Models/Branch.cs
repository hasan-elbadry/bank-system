using System.ComponentModel.DataAnnotations;

namespace bank_system.Models
{
    public class Branch
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Customer>? Customers { get; set; }
    }
}
