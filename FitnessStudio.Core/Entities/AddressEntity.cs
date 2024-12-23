using System.ComponentModel.DataAnnotations;

namespace FitnessProject.Entities
{
    public class AddressEntity
    {

        [Key]
        public uint id { get; set; }
        public string? Street { get; set; }
        public uint? BuildingNumber { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
      
    }
}
