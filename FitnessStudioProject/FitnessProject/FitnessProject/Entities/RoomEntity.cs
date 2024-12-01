namespace FitnessProject.Entities
{
    [Flags]
    public enum Rooms { NIKE = 0, ADIDAS = 1, PUMA = 2, JARDEN = 4, RIBOCK = 8, ALO = 16, LULO_LEMMON = 32 }

    public class RoomEntity
    {
        public int Id { get; set; }
        public Rooms Room { get; set; }
        public int Floor { get; set; }
        public bool IsActive { get; set; }
        public string Code { get; set; }
        public CourseType Suitable { get; set; }
        public int MaxGymnasts { get; set; }
        public string Remark { get; set; }
        public RoomEntity() { }

        public RoomEntity(int id, Rooms room, int floor, bool isActive, string code, CourseType suitable, int maxGymnasts, string remark)
        {
            Id = id;
            Room = room;
            Floor = floor;
            IsActive = isActive;
            Code = code;
            Suitable = suitable;
            MaxGymnasts = maxGymnasts;
            Remark = remark;
        }
    }
}
