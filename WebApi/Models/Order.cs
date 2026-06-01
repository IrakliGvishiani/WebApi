namespace WebApi.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        
        public int OrderAmount { get; set; }

        public string Status { get; set; }

        public decimal Discount { get; set; }

        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public ICollection<OrderItems>? OrderItems { get; set; }
    }
}
