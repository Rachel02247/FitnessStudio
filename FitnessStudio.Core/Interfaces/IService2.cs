using FitnessProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudio.Core.Interfaces
{
    //to id string
    public interface IService2<T>
    {
        List<T>? GetAll();
        T? GetByID(string id);
        T? AddItem(T item);
        T? UpdateItem(string id, T item);
        bool DeleteItem(string id);
    }
}
