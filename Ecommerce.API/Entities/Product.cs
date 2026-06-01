using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.API.Entities
{
    public class Product
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string? ProductName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required]
        [ForeignKey(nameof(Supplier))]
        public Guid? SupplierId { get; set; }
        public Supplier? Supplier { get; set; } 
    }
}
