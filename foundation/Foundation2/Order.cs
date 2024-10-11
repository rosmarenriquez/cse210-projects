// Order.cs
using System.Collections.Generic;

namespace ProductOrderingSystem
{
    public class Order
    {
        private List<Product> Products { get; set; }
        private Customer OrderCustomer { get; set; }
        private const decimal USA_Shipping_Cost = 5.00m;
        private const decimal International_Shipping_Cost = 35.00m;

        public Order(Customer customer)
        {
            Products = new List<Product>();
            OrderCustomer = customer;
        }

        // Method to add a product to the order
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        // Method to calculate the total price of the order
        public decimal TotalPrice()
        {
            decimal totalCost = 0;
            foreach (var product in Products)
            {
                totalCost += product.TotalCost();
            }

            // Add shipping cost based on the customer's location
            if (OrderCustomer.LivesInUSA())
            {
                totalCost += USA_Shipping_Cost;
            }
            else
            {
                totalCost += International_Shipping_Cost;
            }

            return totalCost;
        }

        // Method to get packing label
        public string GetPackingLabel()
        {
            string label = "Packing Label:\n";
            foreach (var product in Products)
            {
                label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
            }
            return label;
        }

        // Method to get shipping label
        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{OrderCustomer.GetName()}\n{OrderCustomer.GetAddress()}";
        }
    }
}