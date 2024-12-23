using FitnessProject.Entities;
using System.Linq.Expressions;
using FitnessStudio.Service;
using FitnessStudio.Core.Interfaces;


namespace FitnessProject.Services
{
    public class GymnastService : IService2<GymnastEntity>
    {
        readonly IRepository2<GymnastEntity> _gymnastService;
        readonly IRepositoryManager _repositoryManager;

        public GymnastService(IRepository2<GymnastEntity> GymnastService, IRepositoryManager repositoryManager)
        {
            _gymnastService = GymnastService;
            _repositoryManager = repositoryManager;
        }
        public List<GymnastEntity>? GetAll()
        {
            return _gymnastService.GetAllDB();
        }
        public GymnastEntity GetByID(string id)
        {
            return _gymnastService.GetByIdDB(id);
        }
        public GymnastEntity? AddItem(GymnastEntity gymnastItem)
        {
            if(!ValidationCheck.IsValidID(gymnastItem.TZ) || !ValidationCheck.IsValidEmail(gymnastItem.Email)) 
                return null;
            GymnastEntity Gymnast = _gymnastService.GetByIdDB(gymnastItem.TZ);
            if (Gymnast != null)
                return null;
            _gymnastService.AddDB(gymnastItem);
            _repositoryManager.Save();
            return _gymnastService.GetByIdDB(gymnastItem.TZ);
        }

        public GymnastEntity? UpdateItem(string id, GymnastEntity gymnastItem)
        {
             if(!ValidationCheck.IsValidID(gymnastItem.TZ) || !ValidationCheck.IsValidEmail(gymnastItem.Email)) 
                return null;
            GymnastEntity Gymnast = _gymnastService.GetByIdDB(id);
            if (Gymnast == null)
                return null;
            _gymnastService.UpdateDB(id, gymnastItem);
            _repositoryManager.Save();
            return _gymnastService.GetByIdDB(id);
        }
        public bool DeleteItem(string id)
        {
            GymnastEntity Gymnast = _gymnastService.GetByIdDB(id);
            if (Gymnast == null)
                return false;
            _gymnastService.DeleteDB(id);
            _repositoryManager.Save();
            return true;
        }

        
    }
}
