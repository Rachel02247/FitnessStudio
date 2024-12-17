using FitnessProject.Entities;
using FitnessStudio.Core.Interfaces;
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
            return _dataContext.LessonList.ToList();
        }
        public int FindIndexInDB(int id)
        {
            return GetAllDB().FindIndex(c => c.Id == id);
        }
        public LessonEntity GetByIdDB(int id)
        {
            int index = FindIndexInDB(id);
            if (_dataContext.LessonList == null || index == -1)
                return null;
            return _dataContext.LessonList.ToList()[index];
        }

        public bool AddDB(LessonEntity lesson)
        {
            try
            {
                if (FindIndexInDB((int)lesson.Id) != -1 || _dataContext.LessonList == null)
                    return false;
                //if (_dataContext == null)
                //    _dataContext.LessonList = new List<LessonEntity>();
                _dataContext.LessonList.Add(lesson);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateDB(int id, LessonEntity lesson)
        {
            try
            {
                int index = FindIndexInDB((int)lesson.Id);
                if (_dataContext.LessonList == null || index == -1)
                    return false;

                //**update all the fields**
                _dataContext.LessonList.ToList()[index].Id = (uint)id;
                if (_dataContext.LessonList.ToList()[index].CourseId != lesson.CourseId)
                    _dataContext.LessonList.ToList()[index].CourseId = lesson.CourseId;
                if (_dataContext.LessonList.ToList()[index].RoomId != lesson.RoomId)
                    _dataContext.LessonList.ToList()[index].Date = lesson.Date;
                if (_dataContext.LessonList.ToList()[index].Date != lesson.Date)
                    _dataContext.LessonList.ToList()[index].Day = lesson.Day;
                if (_dataContext.LessonList.ToList()[index].StartTime != lesson.StartTime)
                    _dataContext.LessonList.ToList()[index].StartTime = lesson.StartTime;
                if (_dataContext.LessonList.ToList()[index].EndTime != lesson.EndTime)
                    _dataContext.LessonList.ToList()[index].EndTime = lesson.EndTime;
                if (_dataContext.LessonList.ToList()[index].ParticipantsAmount != lesson.ParticipantsAmount)
                    _dataContext.LessonList.ToList()[index].ParticipantsAmount = lesson.ParticipantsAmount;

                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteDB(int id)
        {
            try
            {
                int index = FindIndexInDB(id);
                if (_dataContext.LessonList == null || index == -1)
                    return false;
                _dataContext.LessonList.Remove(_dataContext.LessonList.ToList()[index]);
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
