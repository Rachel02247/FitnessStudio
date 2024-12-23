using FitnessProject.Entities;
using FitnessProject.Services;
using FitnessStudio.Core.Interfaces;
using FitnessStudio.Data;
using FitnessStudio.Data.Repository;
using FitnessStudio.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/* ---------Repositories----------*/
builder.Services.AddScoped<IRepository2<GymnastEntity>, GymnastRepository>();
builder.Services.AddScoped<IRepository2<TrainerEntity>, TrainerRepository>();
builder.Services.AddScoped<IRepository<CourseEntity>, CourseRepository>();
builder.Services.AddScoped<IRepository2<RoomEntity>, RoomRepository>();
builder.Services.AddScoped<IRepository<LessonEntity>, LessonRepository>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

/* ---------Services----------*/
builder.Services.AddScoped<IService2<GymnastEntity>, GymnastService>();
builder.Services.AddScoped<IService2<TrainerEntity>, TrainerService>();
builder.Services.AddScoped<IService<CourseEntity>, CourseService>();
builder.Services.AddScoped<IService2<RoomEntity>, RoomService>();
builder.Services.AddScoped<IService<LessonEntity>, LessonService>();

/* ---------DataContext----------*/
builder.Services.AddDbContext<DataContext>();
builder.Services.AddDbContext<DataContext>(option =>
{
    option.UseSqlServer("Data Source = DESKTOP-UT7PC9L; Initial Catalog = FitnessStudio; Integrated Security = true; ");
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
