using System.ComponentModel.DataAnnotations;

namespace FitnessProject.Entities
{
    public class LessonEntity
    {
        [Key]
        public uint Id { get; set; }
        public int  CourseId  { get; set; }
        public int RoomId { get; set; }
        public DateTime Date { get; set; }
        public string Day { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int ParticipantsAmount { get; set; }

        public LessonEntity()
        {

        }
        public LessonEntity(uint id,int courseId, int roomId, DateTime date, string day,
            TimeOnly startTime, TimeOnly endTime, int participantsAmount)
        {
            Id = id;
            CourseId = courseId;
            RoomId = roomId;
            Date = date;
            Day = day;
            StartTime = startTime;
            EndTime = endTime;
            ParticipantsAmount = participantsAmount;
        }
    }
}
