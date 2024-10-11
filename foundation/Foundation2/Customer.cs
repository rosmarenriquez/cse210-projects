// Customer.cs
namespace ProductOrderingSystem
{
    public class Customer
    {
        private string Name { get; set; }
        private Address CustomerAddress { get; set; }

        public Customer(string name, Address address)
        {
            Name = name;
            CustomerAddress = address;
        }

        // Method to check if the customer lives in the USA
        public bool LivesInUSA()
        {
            return CustomerAddress.IsInUSA();
        }

        // Getter for the customer's name
        public string GetName() => Name;

        // Getter for the customer's address
        public Address GetAddress() => CustomerAddress;
    }
}
