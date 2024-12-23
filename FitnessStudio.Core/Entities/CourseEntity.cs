using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessProject.Entities
{
    //[Flags]
    //public enum CourseType { BALLET = 0, FLOOR = 1, AEROBICS = 2, BAYLLA = 4, ZOMBA = 8, HIPHOP = 16, DANCE = 32 }

    public class CourseEntity
    {
        [Key]
        public uint Id {  get; set; }
        public uint courseId { get; set; }
        public string? CourseName { get; set; }
        public uint? MeetingNumbers { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public uint? TrainerId { get; set; }
        public int? IdRoom { get; set; }
        public string? Equipment { get; set; }
        public List<GymnastEntity> Gymnasts { get; set;}
     

    }
}
