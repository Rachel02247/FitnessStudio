using FitnessProject.Entities;
using FitnessStudio.Core.Interfaces;
using FitnessStudio.Core.Interfaces.servcieInterface;
namespace FitnessProject.Services
{
    public class LessonService : ILessonService
    {
        readonly IRepository<LessonEntity> _lessonService;

        public LessonService(IRepository<LessonEntity> lessonService)
        {
            _lessonService = lessonService;
        }
        public List<LessonEntity>? GetAll()
        {
            return _lessonService.GetAllDB();
        }
        public LessonEntity GetByID(int id)
        {
            return _lessonService.GetByIdDB(id);
        }
        public bool AddLesson(LessonEntity Lessondb)
        {
            return _lessonService.AddDB(Lessondb);
        }

        public bool UpdateLesson(int id, LessonEntity lessondb)
        {
            return _lessonService.UpdateDB(id, lessondb);
        }
        public bool DeleteLesson(int id)
        {
            if (id < 0)
                return false;
            return _lessonService.DeleteDB(id);
        }
    }
}
