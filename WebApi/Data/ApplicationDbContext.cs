using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        //private const string ConnectionString = @"Server=WIN-9PN4AK695QF\SQLEXPRESS;Database=WebApi;Trusted_Connection=True;TrustServerCertificate=True;";
        private readonly string ConnectionString;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItems> OrderItems { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);


            });

            modelBuilder.Entity<Order>(entity =>
            {


                entity.Property(o => o.OrderAmount).IsRequired();
                entity.Property(o => o.Status).IsRequired();



                entity.Property(o => o.Discount)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();

                entity.HasOne(o => o.Customer)
                      .WithMany(c => c.Orders)
                      .HasForeignKey(o => o.CustomerId);
            });


            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.ProductName).HasMaxLength(150).IsRequired();
                entity.Property(p => p.Price)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();

                entity.Property(p => p.Quantity).IsRequired();
                entity.HasOne(p => p.Category)
                      .WithMany(c => c.Products)
                      .HasForeignKey(p => p.CategoryId);


                entity.HasOne(p => p.Supplier)
                      .WithMany(s => s.Products)
                      .HasForeignKey(p => p.SupplierId);
            });


            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(c => c.CustomerName).HasMaxLength(100).IsRequired();
                entity.Property(c => c.City).HasMaxLength(50);


                entity.Property(c => c.Email).HasMaxLength(100);
                entity.Property(c => c.PhoneNumber).HasMaxLength(9);

                entity.Property(c => c.LastLoginDate).IsRequired();
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(s => s.SupplierName).HasMaxLength(100).IsRequired();
            });


            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.Property(oi => oi.Quantity).IsRequired();

                entity.Property(oi => oi.PricePerUnit)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.HasOne(oi => oi.Order)
                    .WithMany(o => o.OrderItems)
                    .HasForeignKey(oi => oi.OrderId);

                entity.HasOne(oi => oi.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(oi => oi.ProductId);
            });

            //modelBuilder.Entity<Category>().HasData(
            //    new Category { Id = 1, Name = "Electronics" },
            //    new Category { Id = 2, Name = "Books" },
            //    new Category { Id = 3, Name = "Clothing" },
            //    new Category { Id = 4, Name = "Home & Kitchen" }
            //);

        }
    }
}
