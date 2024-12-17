using FitnessProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudio.Core.Interfaces
{
    public interface IRepository<T>
    {
        public List<T> GetAllDB();
        public T GetByIdDB(int id);
        public bool AddDB(T obj);
        public bool UpdateDB(int id, T obj);
        public bool DeleteDB(int id);
        public int FindIndexInDB(int id);
      



    }
}
