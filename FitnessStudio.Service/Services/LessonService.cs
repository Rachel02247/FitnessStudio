using FitnessProject.Entities;
using System.Linq.Expressions;
using FitnessStudio.Service;
using FitnessStudio.Core.Interfaces;


namespace FitnessProject.Services
{
    public class LessonService : IService<LessonEntity>
    {
        readonly IRepository<LessonEntity> _lessonService;
        readonly IRepositoryManager _repositoryManager;

        public LessonService(IRepository<LessonEntity> lessonService, IRepositoryManager repositoryManager)
        {
            _lessonService = lessonService;
            _repositoryManager = repositoryManager;
        }
        public List<LessonEntity>? GetAll()
        {
            return _lessonService.GetAllDB();
        }
        public LessonEntity? GetByID(int id)
        {
            return _lessonService.GetByIdDB(id);
        }
        public LessonEntity? AddItem(LessonEntity lessonItem)
        {
            LessonEntity lesson = _lessonService.GetByIdDB((int)lessonItem.Id);
            if (lesson != null)
                return null;
            _lessonService.AddDB(lessonItem);
            _repositoryManager.Save();
            return _lessonService.GetByIdDB((int)lessonItem.Id);
        }

        public LessonEntity? UpdateItem(int id, LessonEntity lessonItem)
        {
            LessonEntity lesson = _lessonService.GetByIdDB((int)lessonItem.LessonId);
            if (lesson == null)
                return null;
            _lessonService.UpdateDB(id, lessonItem);
            _repositoryManager.Save();
            return _lessonService.GetByIdDB((int)lessonItem.LessonId);
        }
        public bool DeleteItem(int id)
        {
            LessonEntity lesson = _lessonService.GetByIdDB(id);
            if (lesson == null)
                return false;
            _lessonService.DeleteDB(id);
            _repositoryManager.Save();
            return true;
        }
    }
}
