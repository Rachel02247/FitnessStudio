using System.ComponentModel.DataAnnotations;

namespace FitnessProject.Entities
{

    public class GymnastEntity
    {
        [Key]
        public uint Id { get; set; }

        [Required]
        public string TZ { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? IdAddress { get; set; }
        public List<CourseEntity> Course { get; set; }

      
    }
}
