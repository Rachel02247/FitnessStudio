using FitnessProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudio.Core.Interfaces
{
    //to id int
    public interface IService<T>
    {
        List<T>? GetAll();
        T? GetByID(int id);
        T? AddItem(T item);
        T? UpdateItem(int id, T item);
        bool DeleteItem(int id);
    }
}
