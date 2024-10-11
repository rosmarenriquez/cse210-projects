// Program.cs
using System;

namespace ProductOrderingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create addresses for customers
            Address address1 = new Address("123 Elm St", "Springfield", "IL", "USA");
            Address address2 = new Address("456 Oak St", "Toronto", "ON", "Canada");

            // Create customers
            Customer customer1 = new Customer("John Doe", address1);
            Customer customer2 = new Customer("Jane Smith", address2);

            // Create orders
            Order order1 = new Order(customer1);
            order1.AddProduct(new Product("Laptop", 101, 999.99m, 1));
            order1.AddProduct(new Product("Mouse", 102, 25.50m, 2));

            Order order2 = new Order(customer2);
            order2.AddProduct(new Product("Smartphone", 201, 499.99m, 1));
            order2.AddProduct(new Product("Headphones", 202, 79.99m, 1));

            // Display order details
            DisplayOrderDetails(order1);
            DisplayOrderDetails(order2);
        }

        static void DisplayOrderDetails(Order order)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: {order.TotalPrice():C}\n");
        }
    }
}
