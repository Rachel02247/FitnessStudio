using System.ComponentModel.DataAnnotations;

namespace FitnessProject.Entities
{
    [Flags]
    public enum Rooms { NIKE = 0, ADIDAS = 1, PUMA = 2, JARDEN = 4, RIBOCK = 8, ALO = 16, LULO_LEMMON = 32 }

    public class RoomEntity
    {
        [Key]
        public uint Id { get; set; }
        public string RoomName { get; set; }
        public int Floor { get; set; }
        public bool IsActive { get; set; }
        public string Code { get; set; }
        public int SuitableCourse { get; set; }
        public int MaxGymnasts { get; set; }
        public string Remark { get; set; }
        public RoomEntity() { }

        public RoomEntity(uint id, string roomName, int floor, bool isActive, string code, int suitable, int maxGymnasts, string remark)
        {
            Id = id;
            RoomName = roomName;
            Floor = floor;
            IsActive = isActive;
            Code = code;
            SuitableCourse = suitable;
            MaxGymnasts = maxGymnasts;
            Remark = remark;
        }
    }
}
