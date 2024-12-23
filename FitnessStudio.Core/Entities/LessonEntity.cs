using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessProject.Entities
{
    public class LessonEntity
    {
        [Key]
        public uint Id { get; set; }
        [Required] 
        public uint LessonId { get; set; }
        public uint  CourseId  { get; set; }
        [ForeignKey(nameof(CourseId))]
        public CourseEntity Course { get; set; }

        public uint  RoomId  { get; set; }
        [ForeignKey(nameof(RoomId))]
        public RoomEntity Room { get; set; }

        public DateTime? Date { get; set; }
        public int? Day { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public uint? ParticipantsAmount { get; set; }

    }
}
