////namespace InventoryManagementSystem.Data
////{
////    public class SeedData
////    {
////    }
////}
using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();


            if (!context.Customers.Any())
            {
                context.Customers.AddRange(
                    new Customer { CustomerName = "Ali Ahmed", ContactInfo = "ali@example.com" },
                    new Customer { CustomerName = "Sara Omar", ContactInfo = "sara@example.com" },
                    new Customer { CustomerName = "Mohammed Saleh", ContactInfo = "mohammed@example.com" },
                    new Customer { CustomerName = "Laila Nasser", ContactInfo = "laila@example.com" },
                    new Customer { CustomerName = "Hassan Khalid", ContactInfo = "hassan@example.com" }
                );

                context.SaveChanges();
            }


            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { ProductName = "Laptop", Price = 1500, QuantityInStock = 10 },
                    new Product { ProductName = "Mouse", Price = 50, QuantityInStock = 100 },
                    new Product { ProductName = "Keyboard", Price = 120, QuantityInStock = 80 },
                    new Product { ProductName = "Monitor", Price = 700, QuantityInStock = 25 },
                    new Product { ProductName = "Printer", Price = 900, QuantityInStock = 15 }
                );

                context.SaveChanges();

            }


            if (!context.Orders.Any())
            {
                context.Orders.AddRange(
                    new Order { OrderDate = DateTime.Now.AddDays(-10), CustomerId = 1 },
                    new Order { OrderDate = DateTime.Now.AddDays(-8), CustomerId = 2 },
                    new Order { OrderDate = DateTime.Now.AddDays(-5), CustomerId = 3 },
                    new Order { OrderDate = DateTime.Now.AddDays(-2), CustomerId = 4 },
                    new Order { OrderDate = DateTime.Now, CustomerId = 5 }
                );

                context.SaveChanges();

            }


            if (!context.OrderDetails.Any())
            {
                context.OrderDetails.AddRange(
                    new OrderDetail { OrderId = 1, ProductId = 1, Quantity = 1, UnitPrice = 1500 },
                    new OrderDetail { OrderId = 1, ProductId = 2, Quantity = 2, UnitPrice = 50 },
                    new OrderDetail { OrderId = 2, ProductId = 3, Quantity = 1, UnitPrice = 120 },
                    new OrderDetail { OrderId = 3, ProductId = 4, Quantity = 1, UnitPrice = 700 },
                    new OrderDetail { OrderId = 4, ProductId = 5, Quantity = 1, UnitPrice = 900 }
                );

                context.SaveChanges();

            }


            if (!context.Inventories.Any())
            {
                context.Inventories.AddRange(
                    new Inventory { ProductId = 1, QuantityAvailable = 10, LastUpdated = DateTime.Now },
                    new Inventory { ProductId = 2, QuantityAvailable = 100, LastUpdated = DateTime.Now },
                    new Inventory { ProductId = 3, QuantityAvailable = 80, LastUpdated = DateTime.Now },
                    new Inventory { ProductId = 4, QuantityAvailable = 25, LastUpdated = DateTime.Now },
                    new Inventory { ProductId = 5, QuantityAvailable = 15, LastUpdated = DateTime.Now }
                );

                context.SaveChanges();

            }


            context.SaveChanges();
        }
    }
}

