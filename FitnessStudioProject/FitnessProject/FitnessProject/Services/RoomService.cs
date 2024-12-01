using FitnessProject.Entities;

namespace FitnessProject.Services
{
    public class RoomService
    {
        public List<RoomEntity> RoomList { get; set; }
        public RoomService()
        {
            RoomList = new List<RoomEntity>();
        }
        public bool AddRoom(RoomEntity roomdb)
        {
            if (RoomList == null)
                return false;
            RoomList.Add(roomdb);
            return true;
        }
        public RoomEntity getID(int id)
        {
            if (RoomList == null)
            { return null; }
            return RoomList.Where(c => c.Id == id).FirstOrDefault<RoomEntity>();
        }
        public void UpdateRoom(int id, RoomEntity value)
        {
            RoomList.Insert(id, value);
        }
    }
}
