using FitnessProject.Entities;
using FitnessStudio.Core.Interfaces.servcieInterface;
using FitnessStudio.Core.Interfaces;

namespace FitnessProject.Services
{
    public class RoomService : IRoomService
    {
        readonly IRepository<RoomEntity> _roomService;

        public RoomService(IRepository<RoomEntity> roomService)
        {
            _roomService = roomService;
        }
        public List<RoomEntity>? GetAll()
        {
            return _roomService.GetAllDB();
        }
        public RoomEntity GetByID(int id)
        {
            return _roomService.GetByIdDB(id);
        }
        public bool AddRoom(RoomEntity Roomdb)
        {
            return _roomService.AddDB(Roomdb);
        }

        public bool UpdateRoom(int id, RoomEntity roomdb)
        {
            return _roomService.UpdateDB(id, roomdb);
        }
        public bool DeleteRoom(int id)
        {
            if (id < 0)
                return false;
            return _roomService.DeleteDB(id);
        }
    }
}
