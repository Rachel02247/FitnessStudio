using FitnessProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudio.Core.Interfaces
{
    //to id string
    public interface IRepository2<T>
    {
        List<T> GetAllDB();
        T GetByIdDB(string id);
        T AddDB(T obj);
        T UpdateDB(string id, T obj);
        bool DeleteDB(string id);
    }
}
