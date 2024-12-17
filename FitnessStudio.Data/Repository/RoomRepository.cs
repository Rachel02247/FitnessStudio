using FitnessProject.Entities;
using FitnessStudio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudio.Data.Repository
{
    public class RoomRepository : IRepository<RoomEntity>
    {
        readonly DataContext _dataContext;
        public RoomRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<RoomEntity> GetAllDB()
        {
            return _dataContext.RoomList.ToList();
        }
        public int FindIndexInDB(int id)
        {
            return GetAllDB().FindIndex(c => c.Id == id);
        }
        public RoomEntity GetByIdDB(int id)
        {
            int index = FindIndexInDB(id);
            if (_dataContext.RoomList == null || index == -1)
                return null;
            return _dataContext.RoomList.ToList()[index];
        }

        public bool AddDB(RoomEntity room)
        {
            try
            {
                if (FindIndexInDB((int)room.Id) != -1 || _dataContext.RoomList == null)
                    return false;
                //if (_dataContext == null)
                //    _dataContext.RoomList = new List<RoomEntity>();
                _dataContext.RoomList.Add(room);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateDB(int id, RoomEntity room)
        {
            try
            {
                int index = FindIndexInDB((int)room.Id);
                if (_dataContext.RoomList == null || index == -1)
                    return false;

                //**update all the fields**
                _dataContext.RoomList.ToList()[index].Id = (uint)id;
                if (_dataContext.RoomList.ToList()[index].RoomName != room.RoomName)
                    _dataContext.RoomList.ToList()[index].RoomName = room.RoomName;
                if (_dataContext.RoomList.ToList()[index].Floor != room.Floor)
                    _dataContext.RoomList.ToList()[index].IsActive = room.IsActive;
                if (_dataContext.RoomList.ToList()[index].IsActive != room.IsActive)
                    _dataContext.RoomList.ToList()[index].Code = room.Code;
                if (_dataContext.RoomList.ToList()[index].SuitableCourse != room.SuitableCourse)
                    _dataContext.RoomList.ToList()[index].SuitableCourse = room.SuitableCourse;
                if (_dataContext.RoomList.ToList()[index].MaxGymnasts != room.MaxGymnasts)
                    _dataContext.RoomList.ToList()[index].MaxGymnasts = room.MaxGymnasts;
                if (_dataContext.RoomList.ToList()[index].Remark != room.Remark)
                    _dataContext.RoomList.ToList()[index].Remark = room.Remark;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteDB(int id)
        {
            try
            {
                int index = FindIndexInDB(id);
                if (_dataContext.RoomList == null || index == -1)
                    return false;
                _dataContext.RoomList.Remove(_dataContext.RoomList.ToList()[index]);
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
