using System.ComponentModel.DataAnnotations;

namespace FitnessProject.Entities
{
    [Flags]
    public enum CourseType { BALLET = 0, FLOOR = 1, AEROBICS = 2, BAYLLA = 4, ZOMBA = 8, HIPHOP = 16, DANCE = 32 }

    public class CourseEntity
    {
        [Key]
        public uint Id {  get; set; }
        public string Name { get; set; }
        public uint MeetingNumbers { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public uint TrainerId { get; set; }
        public int IdRoom { get; set; }
        public string Equipment { get; set; }
        public CourseEntity() { }

        public CourseEntity(uint id, string name, uint meetingNumbers, DateTime startDate,
            DateTime endDate, uint trainerId, int idRoom, string equipment)
        {
            Id = id;
            Name = name;
            MeetingNumbers = meetingNumbers;
            StartDate = startDate;
            EndDate = endDate;
            TrainerId = trainerId;
            IdRoom = idRoom;
            Equipment = equipment;
        }

    }
}
