//using FitnessProject.Entities;
//using Microsoft.Extensions.Logging;

//namespace FitnessProject.Services
//{
//    public class CourseService
//    {
//       // public DataContextManager CourseData;
        
//        public List<CourseEntity>? GetAll()
//        {
//            return DataContextManager.Data.CourseList == null ? null : CourseData.Data.CourseList;
//        }
//        public bool AddCourse(CourseEntity coursedb)
//        {
//            if (CourseData.Data.CourseList == null)
//                return false;
//            CourseData.Data.CourseList.Add(coursedb);
//            return true;
//        }
//        public CourseEntity GetByID(int id)
//        {
//            if (CourseData.Data.CourseList == null )
//            { return null; }
//            return CourseData.Data.CourseList.Where(c => c.Id == id).FirstOrDefault<CourseEntity>();
//        }
    
        
//        public void UpdateCourse(int id, CourseEntity value)
//        {
//            CourseData.Data.CourseList.Insert(id, value);
//        }

//    }
//}
