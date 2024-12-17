using FitnessProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudio.Core.Interfaces.servcieInterface
{
    public interface ICourseService
    {
        public List<CourseEntity>? GetAll();
        public CourseEntity GetByID(int id);
        public bool AddCourse(CourseEntity coursedb);
        public bool UpdateCourse(int id, CourseEntity coursedb);
        public bool DeleteCourse(int id);
    }
}
