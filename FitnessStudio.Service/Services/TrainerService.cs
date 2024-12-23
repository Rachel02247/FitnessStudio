using FitnessProject.Entities;
using System.Linq.Expressions;
using FitnessStudio.Service;
using FitnessStudio.Core.Interfaces;


namespace FitnessProject.Services
{
    public class TrainerService : IService2<TrainerEntity>
    {
        readonly IRepository2<TrainerEntity> _trainerService;
        readonly IRepositoryManager _repositoryManager;

        public TrainerService(IRepository2<TrainerEntity> trainerService, IRepositoryManager repositoryManager)
        {
            _trainerService = trainerService;
            _repositoryManager = repositoryManager;
        }
        public List<TrainerEntity>? GetAll()
        {
            return _trainerService.GetAllDB();
        }
        public TrainerEntity? GetByID(string id)
        {
            return _trainerService.GetByIdDB(id);
        }
        public TrainerEntity? AddItem(TrainerEntity trainerItem)
        {
            if (!ValidationCheck.IsValidID(trainerItem.TZ) || !ValidationCheck.IsValidEmail(trainerItem.Email))
                return null;
            TrainerEntity trainer = _trainerService.GetByIdDB(trainerItem.TZ);
            if (trainer != null)
                return null;
            _trainerService.AddDB(trainerItem);
            _repositoryManager.Save();
            return _trainerService.GetByIdDB(trainerItem.TZ);
        }

        public TrainerEntity? UpdateItem(string id, TrainerEntity trainerItem)
        {
            if (!ValidationCheck.IsValidID(trainerItem.TZ) || !ValidationCheck.IsValidEmail(trainerItem.Email))
                return null;
            TrainerEntity trainer = _trainerService.GetByIdDB(id);
            if (trainer == null)
                return null;
            _trainerService.UpdateDB(id, trainerItem);
            _repositoryManager.Save();
            return _trainerService.GetByIdDB(id);
        }
        public bool DeleteItem(string id)
        {
            TrainerEntity trainer = _trainerService.GetByIdDB(id);
            if (trainer == null)
                return false;
            _trainerService.DeleteDB(id);
            _repositoryManager.Save();
            return true;
        }


    }
}
