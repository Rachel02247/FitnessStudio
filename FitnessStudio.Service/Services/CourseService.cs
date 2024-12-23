using FitnessProject.Entities;
using System.Linq.Expressions;
using FitnessStudio.Service;
using FitnessStudio.Core.Interfaces;


namespace FitnessProject.Services
{
    public class CourseService : IService<CourseEntity>
    {
        readonly IRepository<CourseEntity> _courseService;
        readonly IRepositoryManager _repositoryManager;

        public CourseService(IRepository<CourseEntity> courseService, IRepositoryManager repositoryManager)
        {
            _courseService = courseService;
            _repositoryManager = repositoryManager;
        }
        public List<CourseEntity>? GetAll()
        {
            return _courseService.GetAllDB();
        }
        public CourseEntity GetByID(int id)
        {
            return _courseService.GetByIdDB(id);
        }
        public CourseEntity? AddItem(CourseEntity courseItem)
        {
            CourseEntity course = _courseService.GetByIdDB((int)courseItem.Id);
            if (course != null)
                return null;
            _courseService.AddDB(courseItem);
            _repositoryManager.Save();
            return _courseService.GetByIdDB((int)courseItem.Id);
        }

        public CourseEntity? UpdateItem(int id, CourseEntity courseItem)
        {
            CourseEntity course = _courseService.GetByIdDB((int)courseItem.courseId);
            if (course == null)
                return null;
            _courseService.UpdateDB(id, courseItem);
            _repositoryManager.Save();
            return _courseService.GetByIdDB((int)courseItem.courseId);
        }
        public bool DeleteItem(int id)
        {
            CourseEntity course = _courseService.GetByIdDB(id);
            if (course == null)
                return false;
            _courseService.DeleteDB(id);
            _repositoryManager.Save();
            return true;
        }
    }
}
