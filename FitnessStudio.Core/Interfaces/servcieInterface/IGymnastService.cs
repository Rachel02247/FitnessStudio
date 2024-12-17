using FitnessProject.Entities;

namespace FitnessStudio.Core.Interfaces.servcieInterface
{
    public interface IGymnastService
    {

        public List<GymnastEntity>? GetAll();
        public GymnastEntity GetByID(int id);
        public bool AddGymnast(GymnastEntity gymnastdb);
        public bool UpdateGymnast(int id, GymnastEntity gymnastdb);
        public bool DeleteGymnast(int id);
    }

}
