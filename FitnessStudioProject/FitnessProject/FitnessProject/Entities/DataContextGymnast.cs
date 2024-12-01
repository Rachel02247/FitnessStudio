using System.Text.Json;

namespace FitnessProject.Entities
{
    public class DataContextGymnast : IDataContextGymnast
    {
        public List<GymnastEntity> LoadData()
        {
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "data.json");
                string jsonString = File.ReadAllText(path);
                var AllGymnasts = JsonSerializer.Deserialize<List<GymnastEntity>>(jsonString);
                if (AllGymnasts == null)
                    return null; 
                return AllGymnasts;
            }
            catch
            {
                return null;
            }
        }
        public bool SaveData(List<GymnastEntity> data)
        {
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "data.json");
                string jsonString = JsonSerializer.Serialize<List<GymnastEntity>>(data);
                File.WriteAllText(path, jsonString);
                return true;
            }
            catch 
            { 
                return false; 
            }
        }
    }
    }

