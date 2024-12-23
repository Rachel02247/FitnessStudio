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
    public class CourseRepository : IRepository<CourseEntity>
    {
        readonly DataContext _dataContext;
        public CourseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<CourseEntity> GetAllDB()
        {
            return _dataContext.Courses.ToList();
        }
        public CourseEntity? GetByIdDB(int id)
        {
            return _dataContext.Courses.Find(id);
        }

        public CourseEntity? AddDB(CourseEntity course)
        {
            try
            {
                _dataContext.Courses.Add(course);
                return GetByIdDB((int)course.courseId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public CourseEntity? UpdateDB(int id, CourseEntity course)
        {
            try
            {
                CourseEntity curCourse = GetByIdDB(id);

                //**update all the fields**
                if (course.Id > 0 && GetByIdDB((int)course.Id) == null)
                    curCourse.courseId = course.courseId;

                if (!course.CourseName.IsNullOrEmpty())
                    curCourse.CourseName = course.CourseName;

                //nullable
                if (curCourse.MeetingNumbers >= 0)
                    curCourse.MeetingNumbers = course.MeetingNumbers;

                if (course.StartDate != null && DateTime.Compare((DateTime)course.StartDate, new DateTime(1, 1, 2000)) > 0 )
                    curCourse.StartDate = course.StartDate;

                if (course.EndDate != null && DateTime.Compare((DateTime)course.EndDate, new DateTime(1, 1, 2000)) > 0)
                    curCourse.EndDate = course.EndDate;
           
                //only if exist in the trainers db
                if (curCourse.TrainerId != course.TrainerId && _dataContext.Trainers.Find(course.TrainerId) != null)
                    curCourse.TrainerId = course.TrainerId;

                if (curCourse.Equipment != course.Equipment)
                    curCourse.Equipment = course.Equipment;

                return curCourse;
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
                _dataContext.Courses.Remove(GetByIdDB(id));
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
