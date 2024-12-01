namespace FitnessProject.Entities
{
    public interface IDataContextGymnast
    {
        public List<GymnastEntity> LoadData();
        public bool SaveData(List<GymnastEntity> path);
    }
}
