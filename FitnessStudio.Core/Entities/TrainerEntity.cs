using System.ComponentModel.DataAnnotations;

namespace FitnessProject.Entities
{
    public class TrainerEntity
    {
        [Key]
        public int Id { get; set; }
        public string TZ { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int IdAddress { get; set; }

        // public Address Address { get; set; }
        public string Specialization { get; set; }
        public string Diploma { get; set; }
        public TrainerEntity() { }

        public TrainerEntity(int id,string tz, string firstName, string lastName, DateTime dateOfBirth,
            string phoneNumber, string email, int idAddress, /*Address address,*/ string specialization, string diploma)
        {
            Id = id;
            TZ = tz;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            IdAddress = idAddress;
            //Address = address;
            Specialization = specialization;
            Diploma = diploma;
        }
    }
}
