namespace FitnessProject.Entities
{

    public class GymnastEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public CourseType Course { get; set; }

        public GymnastEntity()
        {

        }

        public GymnastEntity(int id, string firstName, string lastName, DateTime dateOfBirth,
            string phoneNumber, string email, Address address, CourseType course)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            Course = course;
        }
    }
}
