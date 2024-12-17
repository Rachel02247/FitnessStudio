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
    public class LessonController : ControllerBase
    {
        //private object result;
        readonly ILessonService _lessonService;
        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
        // GET: api/<LessonController>
        [HttpGet]
        public ActionResult<List<LessonEntity>> Get()
        {
            return _lessonService.GetAll();
        }

        // GET api/<LessonController>/5
        [HttpGet("{id}")]
        public ActionResult<LessonEntity> GetById(int id)
        {
            if (id < 0)
                return BadRequest();
            var lesson = _lessonService.GetByID(id);
            if (lesson == null)
                return NotFound();
            return lesson;
        }
        // POST api/<LessonController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] LessonEntity value)
        {
            bool isSuccess = _lessonService.AddLesson(value);
            if (isSuccess)
                return Ok(true);
            return BadRequest("ID exists in the system or the file do not found");

        }

        // PUT api/<LessonController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] LessonEntity value)
        {
            bool isSuccess = _lessonService.UpdateLesson(id, value);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<LessonController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool isSuccess = _lessonService.DeleteLesson(id);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }


    }
}
