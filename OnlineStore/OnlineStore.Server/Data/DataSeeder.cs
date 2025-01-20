using Microsoft.EntityFrameworkCore;
using OnlineStore.Server.Model;

namespace OnlineStore.Server.Data
{
    public class DataSeeder
    {
        private ModelBuilder modelBuilder; 


        public DataSeeder(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }


        public void Seed()
        {
            // Seed data for Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Whey Protein",
                    Description = "High-quality whey protein for muscle growth.",
                    Category = ItemCategory.Proteins,
                    Price = 29.99m,
                    Quantity = 100
                },
                new Product
                {
                    Id = 2,
                    Name = "Preworkout Booster",
                    Description = "Energy-boosting preworkout supplement.",
                    Category = ItemCategory.PreworkoutSuplements,
                    Price = 19.99m,
                    Quantity = 50
                },
                new Product
                {
                    Id = 3,
                    Name = "Multivitamins",
                    Description = "Daily multivitamins for overall health.",
                    Category = ItemCategory.Vitamins,
                    Price = 14.99m,
                    Quantity = 200
                }
            );

            // Seed data for Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    FullName = "John Doe",
                    Email = "john.doe@example.com",
                    Address = "123 Main St, Anytown, USA"
                },
                new Customer
                {
                    Id = 2,
                    FullName = "Jane Smith",
                    Email = "jane.smith@example.com",
                    Address = "456 Oak St, Othertown, USA"
                }
            );

            // Seed data for Carts
            modelBuilder.Entity<Cart>().HasData(
                new Cart
                {
                    Id = 1,
                    CustomerId = 1
                },
                new Cart
                {
                    Id = 2,
                    CustomerId = 2
                }
            );

            // Seed data for CartItems
            modelBuilder.Entity<CartItem>().HasData(
                new CartItem
                {
                    Id = 1,
                    CartId = 1,
                    ProductId = 1, // Whey Protein
                    Quantity = 2
                },
                new CartItem
                {
                    Id = 2,
                    CartId = 1,
                    ProductId = 2, // Preworkout Booster
                    Quantity = 1
                },
                new CartItem
                {
                    Id = 3,
                    CartId = 2,
                    ProductId = 3, // Multivitamins
                    Quantity = 3
                }
            );

            // Seed data for Orders
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    OrderNumber = Guid.NewGuid().ToString(),  
                    OrderDate = DateTime.Now.AddDays(-1),
                    TotalAmount = 79.97m, // Example total for 2 items in order
                    CustomerId = 1
                },
                new Order
                {
                    Id = 2,
                    OrderNumber = Guid.NewGuid().ToString(),
                    OrderDate = DateTime.Now.AddDays(-2),
                    TotalAmount = 44.97m, // Example total for 3 items in order
                    CustomerId = 2
                }
            );

            // Seed data for OrderItems
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    Id = 1,
                    OrderId = 1,
                    ProductId = 1, // Whey Protein
                    Quantity = 2,
                    UnitPrice = 29.99m
                },
                new OrderItem
                {
                    Id = 2,
                    OrderId = 1,
                    ProductId = 2, // Preworkout Booster
                    Quantity = 1,
                    UnitPrice = 19.99m
                },
                new OrderItem
                {
                    Id = 3,
                    OrderId = 2,
                    ProductId = 3, // Multivitamins
                    Quantity = 3,
                    UnitPrice = 14.99m
                }
            );
        }
    }

}
