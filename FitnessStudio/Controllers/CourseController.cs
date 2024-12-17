//using FitnessProject.Services;
using FitnessProject.Entities;
using FitnessStudio.Core.Interfaces.servcieInterface;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitnessProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        //private object result;
        readonly ICourseService _courseService;
        public CourseController(ICourseService CourseService)
        {
            _courseService = CourseService;
        }
        // GET: api/<CourseController>
        [HttpGet]
        public ActionResult<List<CourseEntity>> Get()
        {
            return _courseService.GetAll();
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public ActionResult<CourseEntity> GetById(int id)
        {
            if (id < 0)
                return BadRequest();
            var course = _courseService.GetByID(id);
            if (course == null)
                return NotFound();
            return course;
        }
        // POST api/<CourseController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] CourseEntity value)
        {
            bool isSuccess = _courseService.AddCourse(value);
            if (isSuccess)
                return Ok(true);
            return BadRequest("ID exists in the system or the file do not found");

        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CourseEntity value)
        {
            bool isSuccess = _courseService.UpdateCourse(id, value);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool isSuccess = _courseService.DeleteCourse(id);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }


    }
}
