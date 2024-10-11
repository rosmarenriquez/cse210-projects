// Address.cs
namespace ProductOrderingSystem
{
    public class Address
    {
        private string Street { get; set; }
        private string City { get; set; }
        private string State { get; set; }
        private string Country { get; set; }

        public Address(string street, string city, string state, string country)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
        }

        // Method to check if the address is in the USA
        public bool IsInUSA()
        {
            return Country.ToLower() == "usa";
        }

        // Method to return the full address as a string
        public override string ToString()
        {
            return $"{Street}\n{City}, {State}\n{Country}";
        }
    }
}
