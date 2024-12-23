using System.Text.Json;
using FitnessProject.Entities;
using FitnessStudio.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Newtonsoft.Json;

namespace FitnessStudio.Data
{
    public class DataContext : DbContext
    {
        public DbSet<GymnastEntity> Gymnasts { get; set; }
        public DbSet<TrainerEntity> Trainers { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<LessonEntity> Lessons { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<RoomPriorityEntity> roomsPriorities { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

    }
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-UT7PC9L; Initial Catalog = FitnessStudio; Integrated Security = true; ");

            return new DataContext(optionsBuilder.Options);
        }
    }

}

