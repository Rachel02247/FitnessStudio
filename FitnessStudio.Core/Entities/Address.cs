namespace FitnessProject.Entities
{
    public class Address
    {
     

        public string Street { get; set; }
        public uint BuildingNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public Address() { }
     
        public Address(string street, uint buildingNumber, string city, string country, string zipCode)
        {
            Street = street;
            BuildingNumber = buildingNumber;
            City = city;
            Country = country;
            ZipCode = zipCode;
        }
    }
}
