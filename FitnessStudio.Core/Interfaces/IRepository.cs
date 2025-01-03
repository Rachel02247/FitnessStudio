﻿using FitnessProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudio.Core.Interfaces
{
    //to id int
    public interface IRepository<T>
    {
        List<T>? GetAllDB();
        T? GetByIdDB(int id);
        T? AddDB(T obj);
        T? UpdateDB(int id, T obj);
        bool DeleteDB(int id);
      



    }
}
