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
    public class TrainerRepository : IRepository2<TrainerEntity>
    {
        readonly DataContext _dataContext;
        public TrainerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<TrainerEntity> GetAllDB()
        {
            return _dataContext.Trainers.ToList();
        }
        public TrainerEntity? GetByIdDB(string id)
        {
            return _dataContext.Trainers.Find(id);
        }

        public TrainerEntity? AddDB(TrainerEntity trainer)
        {
            try
            {
                _dataContext.Trainers.Add(trainer);
                return GetByIdDB(trainer.TZ);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public TrainerEntity? UpdateDB(string id, TrainerEntity trainer)
        {
            try
            {
                TrainerEntity curTrainer = GetByIdDB(id);

                //**update all the fields**
                if (trainer.TZ != curTrainer.TZ)
                    curTrainer.TZ = trainer.TZ;

                if (!trainer.FirstName.IsNullOrEmpty())
                    curTrainer.FirstName = trainer.FirstName;

                //nullable
                if (curTrainer.LastName != trainer.LastName)
                    curTrainer.LastName = trainer.LastName;

                if (trainer.DateOfBirth != null && DateTime.Compare((DateTime)trainer.DateOfBirth, DateTime.Now) != 0)
                    curTrainer.DateOfBirth = trainer.DateOfBirth;

                if (curTrainer.PhoneNumber != trainer.PhoneNumber)
                    curTrainer.PhoneNumber = trainer.PhoneNumber;

                if (curTrainer.Email != trainer.Email)
                    curTrainer.Email = trainer.Email;

                //only if exist in the address db
                if (trainer.IdAddress != curTrainer.IdAddress && _dataContext.Addresses.Find(trainer.IdAddress) != null)
                    curTrainer.IdAddress = trainer.IdAddress;

                if (!trainer.Specialization.IsNullOrEmpty())
                    curTrainer.Specialization = trainer.Specialization;

                if (curTrainer.Diploma != trainer.Diploma)
                    curTrainer.Diploma = trainer.Diploma;

                return curTrainer;
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
                _dataContext.Trainers.Remove(GetByIdDB(id));
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
