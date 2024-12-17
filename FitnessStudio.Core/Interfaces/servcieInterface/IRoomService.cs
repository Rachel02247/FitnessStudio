using FitnessProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudio.Core.Interfaces.servcieInterface
{
    public interface IRoomService
    {
        public List<RoomEntity>? GetAll();
        public RoomEntity GetByID(int id);
        public bool AddRoom(RoomEntity roomdb);
        public bool UpdateRoom(int id, RoomEntity roomdb);
        public bool DeleteRoom(int id);
    }
}
