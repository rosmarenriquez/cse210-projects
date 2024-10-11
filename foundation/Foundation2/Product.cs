// Product.cs
namespace ProductOrderingSystem
{
    public class Product
    {
        private string Name { get; set; }
        private int ProductId { get; set; }
        private decimal Price { get; set; }
        private int Quantity { get; set; }

        public Product(string name, int productId, decimal price, int quantity)
        {
            Name = name;
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        // Method to calculate the total cost of the product
        public decimal TotalCost()
        {
            return Price * Quantity;
        }

        // Getters for the product details
        public string GetName() => Name;
        public int GetProductId() => ProductId;
    }
}
