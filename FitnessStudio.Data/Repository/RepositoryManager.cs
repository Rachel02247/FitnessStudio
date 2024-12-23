using FitnessProject.Entities;
using FitnessStudio.Core.Entities;
using FitnessStudio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudio.Data.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _context;
        public IRepository2<GymnastEntity> Gymnasts { get; }
        public IRepository2<TrainerEntity> Trainers { get; }
        public IRepository<CourseEntity> Courses { get; }
        public IRepository2<RoomEntity> Rooms { get; }
        public IRepository<LessonEntity> Lessons { get; }
        public IRepository<AddressEntity> Addresses { get; }
        public IRepository<RoomPriorityEntity> RoomsPriorities { get; }

        public RepositoryManager(DataContext context, IRepository2<GymnastEntity> gymnasts, IRepository2<TrainerEntity> trainers,
                                 IRepository<CourseEntity> courses, IRepository2<RoomEntity> rooms, IRepository<LessonEntity> lessons,
                                 IRepository<AddressEntity> addresses, IRepository<RoomPriorityEntity> roomsPriorities)
        {
            _context = context;
            Gymnasts = gymnasts;
            Trainers = trainers;
            Courses = courses;
            Rooms = rooms;
            Lessons = lessons;
            Addresses = addresses;
            RoomsPriorities = roomsPriorities;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
