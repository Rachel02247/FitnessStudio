using FitnessProject.Entities;
using FitnessStudio.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudio.Data.Repository
{
    public class CourseRepository : IRepository<CourseEntity>
    {
        readonly DataContext _dataContext;
        public CourseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<CourseEntity> GetAllDB()
        {
            return _dataContext.CourseList.ToList();
        }
        public int FindIndexInDB(int id)
        {
            return GetAllDB().FindIndex(c => c.Id == id);
        }
        public CourseEntity GetByIdDB(int id)
        {
            int index = FindIndexInDB(id);
            if (_dataContext.CourseList == null || index == -1)
                return null;
            return _dataContext.CourseList.ToList()[index];
        }

        public bool AddDB(CourseEntity course)
        {
            try
            {
                if (FindIndexInDB((int)course.Id) != -1 || _dataContext.CourseList == null)
                    return false;
              //  if (_dataContext == null)
              //      _dataContext.CourseList = new DbSet<CourseEntity>();
                _dataContext.CourseList.Add(course);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateDB(int id, CourseEntity course)
        {
            try
            {
                int index = FindIndexInDB((int)course.Id);
                if (_dataContext.CourseList == null || index == -1)
                    return false;

                //**update all the fields**
                _dataContext.CourseList.ToList()[index].Id = (uint)id;
                if (_dataContext.CourseList.ToList()[index].Name != course.Name)
                    _dataContext.CourseList.ToList()[index].Name = course.Name;
                if (_dataContext.CourseList.ToList()[index].MeetingNumbers != course.MeetingNumbers)
                    _dataContext.CourseList.ToList()[index].MeetingNumbers = course.MeetingNumbers;
                if (_dataContext.CourseList.ToList()[index].StartDate != course.EndDate)
                    _dataContext.CourseList.ToList()[index].StartDate = course.StartDate;
                if (_dataContext.CourseList.ToList()[index].EndDate != course.EndDate)
                    _dataContext.CourseList.ToList()[index].EndDate = course.EndDate;
                if (_dataContext.CourseList.ToList()[index].TrainerId != course.TrainerId)
                    _dataContext.CourseList.ToList()[index].TrainerId = course.TrainerId;
                if (_dataContext.CourseList.ToList()[index].IdRoom != course.IdRoom)
                    _dataContext.CourseList.ToList()[index].IdRoom = course.IdRoom;
                if (_dataContext.CourseList.ToList()[index].Equipment != course.Equipment)
                    _dataContext.CourseList.ToList()[index].Equipment = course.Equipment;

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
                if (_dataContext.CourseList == null || index == -1)
                    return false;
                _dataContext.CourseList.Remove(_dataContext.CourseList.ToList()[index]);
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
