namespace WebApi.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Guid CategoryId { get; set; }
        public Guid SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        public Category? Category { get; set; }

        public ICollection<OrderItems>? OrderItems { get; set; }
    }
}
