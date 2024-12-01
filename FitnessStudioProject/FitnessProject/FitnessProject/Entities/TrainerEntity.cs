namespace FitnessProject.Entities
{
    public class TrainerEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Specialization { get; set; }
        public string Diploma { get; set; }
        public TrainerEntity() { }

        public TrainerEntity(int id, string firstName, string lastName, DateTime dateOfBirth,
            string phoneNumber, string email, Address address, string specialization, string diploma)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            Specialization = specialization;
            Diploma = diploma;
        }
    }
}
