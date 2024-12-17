using FitnessProject.Entities;
using FitnessStudio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudio.Data.Repository
{
    public class TrainerRepository : IRepository<TrainerEntity>
    {
        readonly DataContext _dataContext;
        public TrainerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<TrainerEntity> GetAllDB()
        {
            return _dataContext.TrainerList.ToList();
        }
        public int FindIndexInDB(int id)
        {
            return GetAllDB().FindIndex(c => c.Id == id);
        }
        public TrainerEntity GetByIdDB(int id)
        {
            int index = FindIndexInDB(id);
            if (_dataContext.TrainerList == null || index == -1)
                return null;
            return _dataContext.TrainerList.ToList()[index];
        }

        public bool AddDB(TrainerEntity trainer)
        {
            try
            {
                if (FindIndexInDB((int)trainer.Id) != -1 || _dataContext.TrainerList == null)
                    return false;
                //if (_dataContext == null)
                //    _dataContext.TrainerList = new List<TrainerEntity>();
                _dataContext.TrainerList.Add(trainer);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateDB(int id, TrainerEntity trainer)
        {
            try
            {
                int index = FindIndexInDB((int)trainer.Id);
                if (_dataContext.TrainerList == null || index == -1)
                    return false;

                //**update all the fields**
                //// _dataContext.TrainerList[index].Id = (uint)id;
                if (_dataContext.TrainerList.ToList()[index].TZ != trainer.TZ)
                    _dataContext.TrainerList.ToList()[index].TZ = trainer.TZ;
                if (_dataContext.TrainerList.ToList()[index].FirstName != trainer.FirstName)
                    _dataContext.TrainerList.ToList()[index].FirstName = trainer.TZ;
                if (_dataContext.TrainerList.ToList()[index].LastName != trainer.LastName)
                    _dataContext.TrainerList.ToList()[index].LastName = trainer.LastName;
                if (_dataContext.TrainerList.ToList()[index].DateOfBirth != trainer.DateOfBirth)
                    _dataContext.TrainerList.ToList()[index].DateOfBirth = trainer.DateOfBirth;
                if (_dataContext.TrainerList.ToList()[index].PhoneNumber != trainer.PhoneNumber)
                    _dataContext.TrainerList.ToList()[index].PhoneNumber = trainer.PhoneNumber;
                if (_dataContext.TrainerList.ToList()[index].Email != trainer.Email)
                    _dataContext.TrainerList.ToList()[index].Email = trainer.Email;
                if (_dataContext.TrainerList.ToList()[index].IdAddress != trainer.IdAddress)
                    _dataContext.TrainerList.ToList()[index].IdAddress = trainer.IdAddress;
                //if (_dataContext.TrainerList[index].Address != trainer.Address)
                //    _dataContext.TrainerList[index].Address = trainer.Address;
                if (_dataContext.TrainerList.ToList()[index].Specialization != trainer.Specialization)
                    _dataContext.TrainerList.ToList()[index].Specialization = trainer.Specialization;
                if (_dataContext.TrainerList.ToList()[index].Diploma != trainer.Diploma)
                    _dataContext.TrainerList.ToList()[index].Diploma = trainer.Diploma;

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
                if (_dataContext.TrainerList == null || index == -1)
                    return false;
                _dataContext.TrainerList.Remove(_dataContext.TrainerList.ToList()[index]);
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
