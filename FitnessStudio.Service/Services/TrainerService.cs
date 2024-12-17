using FitnessProject.Entities;
using FitnessStudio.Core.Interfaces;
using FitnessStudio.Service;
using FitnessStudio.Core.Interfaces.servcieInterface;
namespace FitnessProject.Services
{
    public class TrainerService : ITrainerService
    {
        readonly IRepository<TrainerEntity> _trainerService;

        public TrainerService(IRepository<TrainerEntity> trainerService)
        {
            _trainerService = trainerService;
        }
        public List<TrainerEntity>? GetAll()
        {
            return _trainerService.GetAllDB();
        }
        public TrainerEntity GetByID(int id)
        {
            return _trainerService.GetByIdDB(id);
        }
        public bool AddTrainer(TrainerEntity trainerdb)
        {
            if (!ValidationCheck.IsValidID(trainerdb.TZ) || !ValidationCheck.IsValidEmail(trainerdb.Email))
                return false;
            return _trainerService.AddDB(trainerdb);
        }

        public bool UpdateTrainer(int id, TrainerEntity trainerdb)
        {
            if (!ValidationCheck.IsValidID(trainerdb.TZ) || !ValidationCheck.IsValidEmail(trainerdb.Email))
                return false;
            return _trainerService.UpdateDB(id, trainerdb);
        }
        public bool DeleteTrainer(int id)
        {
            if (id < 0)
                return false;
            return _trainerService.DeleteDB(id);
        }

    }
}
