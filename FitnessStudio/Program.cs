using FitnessProject.Entities;
using FitnessProject.Services;
using FitnessStudio.Core.Interfaces.servcieInterface;
using FitnessStudio.Data;
using FitnessStudio.Data.Repository;
using FitnessStudio.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IGymnastService, GymnastService>();
builder.Services.AddSingleton<IRepository<GymnastEntity>, GymnastRepository>();
builder.Services.AddDbContext<DataContext>(option =>
{
    option.UseSqlServer("Data Source = DESKTOP-UT7PC9L; Initial Catalog = FitnessStudio; Integrated Security = true; ");
});
//builder.Services.AddSingleton<DataContext>();


builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IRepository<CourseEntity>, CourseRepository>();
builder.Services.AddDbContext<DataContext>(option =>
{
    option.UseSqlServer("Data Source = DESKTOP-UT7PC9L; Initial Catalog = FitnessStudio; Integrated Security = true; ");
});
builder.Services.AddScoped<DataContext>();

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
