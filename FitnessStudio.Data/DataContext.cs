using System.Text.Json;
using FitnessProject.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FitnessStudio.Data
{
    public class DataContext : DbContext
    {
        public DbSet<GymnastEntity> GymnastList { get; set; }
        public DbSet<TrainerEntity> TrainerList { get; set; }
        public DbSet<CourseEntity> CourseList { get; set; }
        public DbSet<RoomEntity> RoomList { get; set; }
        public DbSet<LessonEntity> LessonList { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

    }
   }

