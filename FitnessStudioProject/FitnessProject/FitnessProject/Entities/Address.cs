namespace FitnessProject.Entities
{
    public class Address
    {
     

        public string Street { get; set; }
        public int BuildingNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }
        public Address() { }
     
        public Address(string street, int buildingNumber, string city, string country, int zipCode)
        {
            Street = street;
            BuildingNumber = buildingNumber;
            City = city;
            Country = country;
            ZipCode = zipCode;
        }
    }
}
