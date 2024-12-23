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
    public class GymnastRepository : IRepository2<GymnastEntity>
    {
        readonly DataContext _dataContext;
        public GymnastRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<GymnastEntity> GetAllDB()
        {
            return _dataContext.Gymnasts.ToList();
        }
        public GymnastEntity? GetByIdDB(string id)
        {
            return _dataContext.Gymnasts.Find(id);
        }

        public GymnastEntity? AddDB(GymnastEntity gymnast)
        {
            try
            {
                _dataContext.Gymnasts.Add(gymnast);
                return GetByIdDB(gymnast.TZ);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public GymnastEntity? UpdateDB(string id, GymnastEntity gymnast)
        {
            try
            {
                GymnastEntity curGymnast = GetByIdDB(id);

                //**update all the fields**
                if (gymnast.TZ != curGymnast.TZ)
                 curGymnast.TZ = gymnast.TZ;

                if (!gymnast.FirstName.IsNullOrEmpty())
                 curGymnast.FirstName = gymnast.FirstName;

                //nullable
                if (curGymnast.LastName != gymnast.LastName)
                 curGymnast.LastName = gymnast.LastName;

                if (gymnast.DateOfBirth != null && DateTime.Compare((DateTime)gymnast.DateOfBirth, DateTime.Now) != 0)
                 curGymnast.DateOfBirth = gymnast.DateOfBirth;

                if (curGymnast.PhoneNumber != gymnast.PhoneNumber)
                 curGymnast.PhoneNumber = gymnast.PhoneNumber;

                if (curGymnast.Email != gymnast.Email)
                 curGymnast.Email = gymnast.Email;

                //only if exist in the address db
                if (gymnast.IdAddress != curGymnast.IdAddress && _dataContext.Addresses.Find(gymnast.IdAddress) != null)
                 curGymnast.IdAddress = gymnast.IdAddress;
                
               return curGymnast;
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
                _dataContext.Gymnasts.Remove(GetByIdDB(id));
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
