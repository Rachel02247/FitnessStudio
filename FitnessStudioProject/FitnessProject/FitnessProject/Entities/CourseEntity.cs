namespace FitnessProject.Entities
{
    [Flags]
    public enum CourseType { BALLET = 0, FLOOR = 1, AEROBICS = 2, BAYLLA = 4, ZOMBA = 8, HIPHOP = 16, DANCE = 32 }

    public class CourseEntity
    {
        public int Id {  get; set; }
        public CourseType Name { get; set; }
        public int MeetingNumbers { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TrainerId { get; set; }
        public Rooms PreferredRoom { get; set; }
        public string Equipment { get; set; }
        public CourseEntity() { }

        public CourseEntity(CourseType name, int meetingNumbers, DateTime startDate,
            DateTime endDate, int trainerId, Rooms preferredRoom, string equipment)
        {
            
            Name = name;
            MeetingNumbers = meetingNumbers;
            StartDate = startDate;
            EndDate = endDate;
            TrainerId = trainerId;
            PreferredRoom = preferredRoom;
            Equipment = equipment;
        }

    }
}
