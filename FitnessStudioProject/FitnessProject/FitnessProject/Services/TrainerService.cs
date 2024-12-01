using FitnessProject.Entities;

namespace FitnessProject.Services
{
    public class TrainerService
    {
        public List<TrainerEntity> TrainerList { get; set; }
        public TrainerService()
        {
            TrainerList = new List<TrainerEntity>();
        }
        public bool AddTrainer(TrainerEntity trainerdb)
        {
            if (TrainerList == null)
                return false;
            TrainerList.Add(trainerdb);
            return true;
        }
        public TrainerEntity getID(int id)
        {
            if (TrainerList == null)
            { return null; }
            return TrainerList.Where(c => c.Id == id).FirstOrDefault<TrainerEntity>();
        }
        public void UpdateTrainer(int id, TrainerEntity value)
        {
            TrainerList.Insert(id, value);
        }
    
}
}
