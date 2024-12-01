using FitnessProject.Entities;
using System.Linq.Expressions;

namespace FitnessProject.Services
{
    public class GymnastService
    {
        readonly IDataContextGymnast _gymnastService;

        public GymnastService(IDataContextGymnast gymnastService)
        {
            _gymnastService = gymnastService;
        }
        public List<GymnastEntity>? GetAll()
        {
            var data = _gymnastService.LoadData();
            return data == null ? null : data;
        }
        public GymnastEntity GetByID(int id)
        {
            var data = _gymnastService.LoadData();
            if (data == null || data.FindIndex(c => c.Id == id) == -1)
                return null;
            return data.Where(c => c.Id == id).FirstOrDefault();
        }
        public bool AddGymnast(GymnastEntity gymnastdb)
        {
            var data = _gymnastService.LoadData();
            if(data == null)
               return false;
            if ( data.Find(c => c.Id == gymnastdb.Id) != null || !ValidationCheck.IsValidID(gymnastdb.Id.ToString()) || !ValidationCheck.IsValidEmail(gymnastdb.Email))
                return false;
            data.Add(gymnastdb);
            return _gymnastService.SaveData(data);
        }
       
        public bool UpdateGymnast(int id, GymnastEntity gymnastdb)
        {
            var data = _gymnastService.LoadData();
            if (data == null || data.Find(c => c.Id == id) == null)
                return false;
            int index = data.FindIndex(c => c.Id == id);
            data[index] = gymnastdb;
            return _gymnastService.SaveData(data);
        }
        public bool DeleteGymnast(int id)
        {
            if (id < 0) 
                return false;   
            var data = _gymnastService.LoadData();
            if(data == null || data.Find(c => c.Id == id) == null )
                return false;
            data.Remove(data.Find(c => c.Id == id));
            return _gymnastService.SaveData(data);
        }

    }
}

