//using FitnessStudio.Data;
using FitnessStudio.Core.Interfaces;
using FitnessProject.Entities;
using System.Linq.Expressions;
using FitnessStudio.Service;
using FitnessStudio.Core.Interfaces.servcieInterface;

namespace FitnessProject.Services
{
    public class GymnastService : IGymnastService
    {
        readonly IRepository<GymnastEntity> _gymnastService;

        public GymnastService(IRepository<GymnastEntity> gymnastService)
        {
            _gymnastService = gymnastService;
        }
        public List<GymnastEntity>? GetAll()
        {
            return _gymnastService.GetAllDB();
        }
        public GymnastEntity GetByID(int id)
        {
            return _gymnastService.GetByIdDB(id);
        }
        public bool AddGymnast(GymnastEntity gymnastdb)
        {
            if (!ValidationCheck.IsValidID(gymnastdb.TZ) || !ValidationCheck.IsValidEmail(gymnastdb.Email))
                return false;
            return _gymnastService.AddDB(gymnastdb);
        }
       
        public bool UpdateGymnast(int id, GymnastEntity gymnastdb)
        {
            if (!ValidationCheck.IsValidID(gymnastdb.TZ) || !ValidationCheck.IsValidEmail(gymnastdb.Email))
                return false;
            return _gymnastService.UpdateDB(id, gymnastdb);
        }
        public bool DeleteGymnast(int id)
        {
            if (id < 0) 
                return false;
            return _gymnastService.DeleteDB(id);
        }

    }
}

