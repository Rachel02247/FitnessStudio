using FitnessProject.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FitnessProject.Services
{
    public class LessonService
    {
        public DataContextManager LessonList;
        
        public List<LessonEntity>? GetAll()
        {
            return LessonList.Data.LessontList == null ? null : LessonList.Data.LessontList;
        }
        public bool AddLesson(LessonEntity lessondb)
        {
            if (LessonList.Data.LessontList == null)
                return false;
            LessonList.Data.LessontList.Add(lessondb);
            return true;
        }
        public LessonEntity GetByID(int id)
        {
            if (id < 0)
                return BadRequest();
            if (LessonList.Data.LessontList == null)
            { return null; }
            return LessonList.Data.LessontList.Where(c => c.Id == id).FirstOrDefault<LessonEntity>();
        }

        private LessonEntity BadRequest()
        {
            throw new NotImplementedException();
        }

        public void UpdateLesson(int id, LessonEntity value)
        {
          //  LessonList.Insert(id, value);
        }
    }
}
