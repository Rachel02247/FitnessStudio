using FitnessProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudio.Core.Interfaces.servcieInterface
{
    public interface ILessonService
    {
        public List<LessonEntity>? GetAll();
        public LessonEntity GetByID(int id);
        public bool AddLesson(LessonEntity lessondb);
        public bool UpdateLesson(int id, LessonEntity lessondb);
        public bool DeleteLesson(int id);
    }
}
