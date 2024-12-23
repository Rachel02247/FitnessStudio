using FitnessProject.Entities;
using FitnessStudio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudio.Core.Interfaces
{
    public interface IRepositoryManager
    {
        IRepository2<GymnastEntity> Gymnasts { get; }
        IRepository2<TrainerEntity> Trainers { get; }
        IRepository<CourseEntity> Courses { get; }
        IRepository2<RoomEntity> Rooms { get; }
        IRepository<LessonEntity> Lessons { get; }
        IRepository<AddressEntity> Addresses { get; }
        IRepository<RoomPriorityEntity> RoomsPriorities { get; }
        void Save();
    }
}
