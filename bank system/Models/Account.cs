using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace bank_system.Models
{
    public class Account
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string AccountNumber { get; set; } = string.Empty; // unique
        [Range(0,double.MaxValue)]
        public decimal Balance { get; set; } 
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
