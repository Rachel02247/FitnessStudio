using FitnessProject.Entities;
using FitnessStudio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudio.Data.Repository
{
    public class GymnastRepository : IRepository<GymnastEntity>
    {
        readonly DataContext _dataContext;
        public GymnastRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<GymnastEntity> GetAllDB()
        {
            return _dataContext.GymnastList.ToList();
        }
        public int FindIndexInDB(int id)
        {
            return GetAllDB().FindIndex(c => c.Id == id);
        }
        public GymnastEntity GetByIdDB(int id)
        {
            int index = FindIndexInDB(id);
            if (_dataContext.GymnastList == null || index == -1)
                return null;
            return _dataContext.GymnastList.ToList()[index];
        }

        public bool AddDB(GymnastEntity gymnast)
        {
            try
            {
                if(FindIndexInDB((int)gymnast.Id) != -1 || _dataContext.CourseList == null)
                    return false;
                //if (_dataContext == null)
                //    _dataContext.GymnastList = new List<GymnastEntity>();
                _dataContext.GymnastList.Add(gymnast);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateDB(int id, GymnastEntity gymnast)
        {
            try
            {
                int index = FindIndexInDB((int)gymnast.Id);
                if (_dataContext.GymnastList == null || index == -1)
                    return false;

                //**update all the fields**
                //// _dataContext.GymnastList[index].Id = (uint)id;
                if (_dataContext.GymnastList.ToList()[index].TZ != gymnast.TZ)
                    _dataContext.GymnastList.ToList()[index].TZ = gymnast.TZ;
                if (_dataContext.GymnastList.ToList()[index].FirstName != gymnast.FirstName)
                    _dataContext.GymnastList.ToList()[index].FirstName = gymnast.TZ;
                if (_dataContext.GymnastList.ToList()[index].LastName != gymnast.LastName)
                    _dataContext.GymnastList.ToList()[index].LastName = gymnast.LastName;
                if (_dataContext.GymnastList.ToList()[index].DateOfBirth != gymnast.DateOfBirth)
                    _dataContext.GymnastList.ToList()[index].DateOfBirth = gymnast.DateOfBirth;
                if (_dataContext.GymnastList.ToList()[index].PhoneNumber != gymnast.PhoneNumber)
                    _dataContext.GymnastList.ToList()[index].PhoneNumber = gymnast.PhoneNumber;
                if (_dataContext.GymnastList.ToList()[index].Email != gymnast.Email)
                    _dataContext.GymnastList.ToList()[index].Email = gymnast.Email;
                if (_dataContext.GymnastList.ToList()[index].IdAddress != gymnast.IdAddress)
                    _dataContext.GymnastList.ToList()[index].IdAddress = gymnast.IdAddress;
                //  if (_dataContext.GymnastList[index].Address != gymnast.Address)
                //      _dataContext.GymnastList[index].Address = gymnast.Address;
                if (_dataContext.GymnastList.ToList()[index].IdCourse != gymnast.IdCourse)
                    _dataContext.GymnastList.ToList()[index].IdCourse = gymnast.IdCourse;
             
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
                if (_dataContext.GymnastList == null || index == -1 )
                return false;
                _dataContext.GymnastList.Remove(_dataContext.GymnastList.ToList()[index]);
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
