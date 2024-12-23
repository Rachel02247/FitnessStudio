using FitnessProject.Entities;
using System.Linq.Expressions;
using FitnessStudio.Service;
using FitnessStudio.Core.Interfaces;


namespace FitnessProject.Services
{
    public class RoomService : IService2<RoomEntity>
    {
        readonly IRepository2<RoomEntity> _roomService;
        readonly IRepositoryManager _repositoryManager;

        public RoomService(IRepository2<RoomEntity> roomService, IRepositoryManager repositoryManager)
        {
            _roomService = roomService;
            _repositoryManager = repositoryManager;
        }
        public List<RoomEntity>? GetAll()
        {
            return _roomService.GetAllDB();
        }
        public RoomEntity GetByID(string id)
        {
            return _roomService.GetByIdDB(id);
        }
        public RoomEntity? AddItem(RoomEntity roomItem)
        {
            RoomEntity room = _roomService.GetByIdDB(roomItem.Code);
            if (room != null)
                return null;
            _roomService.AddDB(roomItem);
            _repositoryManager.Save();
            return _roomService.GetByIdDB(roomItem.Code);
        }

        public RoomEntity? UpdateItem(string id, RoomEntity roomItem)
        {
            RoomEntity room = _roomService.GetByIdDB(id);
            if (room == null)
                return null;
            _roomService.UpdateDB(id, roomItem);
            _repositoryManager.Save();
            return _roomService.GetByIdDB(id);
        }
        public bool DeleteItem(string id)
        {
            RoomEntity room = _roomService.GetByIdDB(id);
            if (room == null)
                return false;
            _roomService.DeleteDB(id);
            _repositoryManager.Save();
            return true;
        }


    }
}
