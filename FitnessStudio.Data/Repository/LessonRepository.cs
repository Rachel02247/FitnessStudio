using FitnessProject.Entities;
using FitnessStudio.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudio.Data.Repository
{
    public class LessonRepository : IRepository<LessonEntity>
    {
        readonly DataContext _dataContext;
        public LessonRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<LessonEntity> GetAllDB()
        {
            return _dataContext.Lessons.ToList();
        }
        public LessonEntity? GetByIdDB(int id)
        {
            return _dataContext.Lessons.Find(id);
        }

        public LessonEntity? AddDB(LessonEntity lesson)
        {
            try
            {
                _dataContext.Lessons.Add(lesson);
                return GetByIdDB((int)lesson.LessonId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public LessonEntity? UpdateDB(int id, LessonEntity lesson)
        {
            try
            {
                LessonEntity curLesson = GetByIdDB(id);

                //**update all the fields**

                if (lesson.LessonId > 0 && GetByIdDB((int)lesson.LessonId) == null)
                    curLesson.LessonId = lesson.LessonId;

                //only if exist in the courses db
                if (curLesson.CourseId != lesson.CourseId && _dataContext.Courses.Find(lesson.CourseId) != null)
                    curLesson.CourseId = lesson.CourseId;
                
                //only if exist in the rooms db
                if (curLesson.RoomId != lesson.RoomId && _dataContext.Rooms.Find(lesson.RoomId) != null)
                    curLesson.RoomId = lesson.RoomId;

           
                if (lesson.Date != null && DateTime.Compare((DateTime)lesson.Date, new DateTime(1, 1, 2000)) > 0)
                    curLesson.Date = lesson.Date;

                if (lesson.Day > 0 && lesson.Day < 7)
                    curLesson.Day = lesson.Day;

                if (lesson.StartTime != null)
                    curLesson.StartTime = lesson.StartTime;
                
                if (lesson.EndTime != null)
                    curLesson.EndTime = lesson.EndTime;


                if (curLesson.ParticipantsAmount >= 0)
                    curLesson.ParticipantsAmount = lesson.ParticipantsAmount;

                return curLesson;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool DeleteDB(int id)
        {
            try
            {
                _dataContext.Lessons.Remove(GetByIdDB(id));
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
