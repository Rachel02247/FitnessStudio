using FitnessProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudio.Core.Interfaces.servcieInterface
{
    public interface ITrainerService
    {
        public List<TrainerEntity>? GetAll();
        public TrainerEntity GetByID(int id);
        public bool AddTrainer(TrainerEntity trainerdb);
        public bool UpdateTrainer(int id, TrainerEntity trainerdb);
        public bool DeleteTrainer(int id);
    }
}
