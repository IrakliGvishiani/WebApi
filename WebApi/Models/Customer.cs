using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Customer
    {
        [Required]
        public Guid Id { get; set; }

        public string? CustomerName { get; set; }

        public string? City { get; set; }
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
