using Microsoft.EntityFrameworkCore;
using OnlineStore.Server.Model;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace OnlineStore.Server.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }



        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure one-to-one relationship between Customer and Cart
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Cart)
                .WithOne(cart => cart.Customer)
                .HasForeignKey<Cart>(cart => cart.CustomerId);

            // Configure one-to-many relationship between Customer and Orders
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);

            // Configure one-to-many relationship between Cart and CartItems
            modelBuilder.Entity<Cart>()
                .HasMany(cart => cart.CartItems)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId);

            // Configure one-to-many relationship between Order and OrderItems
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            // Configure one-to-many relationship between Product and CartItems
            modelBuilder.Entity<Product>()
                .HasMany<CartItem>()
                .WithOne(ci => ci.Product)
                .HasForeignKey(ci => ci.ProductId);

            // Configure one-to-many relationship between Product and OrderItems
            modelBuilder.Entity<Product>()
                .HasMany<OrderItem>()
                .WithOne(oi => oi.Product)
                .HasForeignKey(oi => oi.ProductId);

            // Seeding
            DataSeeder dataSeeder = new DataSeeder(modelBuilder);
            dataSeeder.Seed();
        }
    }
}