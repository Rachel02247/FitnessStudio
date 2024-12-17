using FitnessProject.Entities;
using System.Linq.Expressions;
using FitnessStudio.Service;
using FitnessStudio.Core.Interfaces;
using FitnessStudio.Core.Interfaces.servcieInterface;


namespace FitnessProject.Services
{
    public class CourseService : ICourseService
    {
        readonly IRepository<CourseEntity> _courseService;

        public CourseService(IRepository<CourseEntity> courseService)
        {
            _courseService = courseService;
        }
        public List<CourseEntity>? GetAll()
        {
            return _courseService.GetAllDB();
        }
        public CourseEntity GetByID(int id)
        {
            return _courseService.GetByIdDB(id);
        }
        public bool AddCourse(CourseEntity Coursedb)
        {
            return _courseService.AddDB(Coursedb);
        }

        public bool UpdateCourse(int id, CourseEntity coursedb)
        {
            return _courseService.UpdateDB(id, coursedb);
        }
        public bool DeleteCourse(int id)
        {
            if (id < 0)
                return false;
            return _courseService.DeleteDB(id);
        }

    }
}
