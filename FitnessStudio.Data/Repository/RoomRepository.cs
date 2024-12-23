using FitnessProject.Entities;
using FitnessStudio.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudio.Data.Repository
{
    public class RoomRepository : IRepository2<RoomEntity>
    {
        readonly DataContext _dataContext;
        public RoomRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<RoomEntity> GetAllDB()
        {
            return _dataContext.Rooms.ToList();
        }
        public RoomEntity? GetByIdDB(string id)
        {
            return _dataContext.Rooms.Find(id);
        }

        public RoomEntity? AddDB(RoomEntity room)
        {
            try
            {
                _dataContext.Rooms.Add(room);
                return GetByIdDB(room.Code);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public RoomEntity? UpdateDB(string id, RoomEntity room)
        {
            try
            {
                RoomEntity curRoom = GetByIdDB(id);

                //**update all the fields**
                if (!room.RoomName.IsNullOrEmpty())
                    curRoom.RoomName = room.RoomName;

                //nullable
                if (curRoom.Floor != room.Floor)
                    curRoom.Floor = room.Floor;

                if (curRoom.IsActive != room.IsActive)
                    curRoom.IsActive = room.IsActive;

                if (!room.Code.IsNullOrEmpty())
                    curRoom.Code = room.Code;

                if (curRoom.MaxGymnasts >= 0)
                    curRoom.MaxGymnasts = room.MaxGymnasts;

                if (curRoom.Remark != room.Remark)
                    curRoom.Remark = room.Remark;

                return curRoom;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool DeleteDB(string id)
        {
            try
            {
                _dataContext.Rooms.Remove(GetByIdDB(id));
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
