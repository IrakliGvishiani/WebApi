using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Supplier
    {
        [Required]
        public Guid Id { get; set; }

        public string? SupplierName { get; set; }

       public ICollection<Product>? Products { get; set; }
    }
}
