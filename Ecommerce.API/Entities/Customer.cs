using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.API.Entities
{
    public class Customer
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string? CustomerName { get; set; }

        [MaxLength(100)]
        public string? City { get; set; }

        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [MaxLength(20)]
        [Phone]
        [Column(TypeName = "varchar(20)")]
        public string? PhoneNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LastLoginDate { get; set; } = DateTime.Now.Date;


        public ICollection<Order>? Orders { get; set; }
    }
}
