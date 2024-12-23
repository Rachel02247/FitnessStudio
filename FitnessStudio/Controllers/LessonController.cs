//using FitnessProject.Services;
using FitnessProject.Entities;
using FitnessStudio.Core.Interfaces;
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
        readonly IService<LessonEntity> _lessonService;
        public LessonController(IService<LessonEntity> lessonService)
        {
            _lessonService = lessonService;
        }
        // GET: api/<LessonController>
        [HttpGet]
        public ActionResult<List<LessonEntity>>? Get()
        {
            return _lessonService.GetAll();
        }

        // GET api/<LessonController>/5
        [HttpGet("{id}")]
        public ActionResult<LessonEntity> GetById(int id)
        {
            if (id < 0)
                return BadRequest();
            var Lesson = _lessonService.GetByID(id);
            if (Lesson == null)
                return NotFound();
            return Lesson;
        }
        // POST api/<LessonController>
        [HttpPost]
        public ActionResult<LessonEntity> Post([FromBody] LessonEntity value)
        {
            LessonEntity isSuccess = _lessonService.AddItem(value);
            if (isSuccess != null)
                return Ok(true);
            return BadRequest("ID exists in the system or the file do not found");
        }

        // PUT api/<LessonController>/5
        [HttpPut("{id}")]
        public ActionResult<LessonEntity> Put(int id, [FromBody] LessonEntity value)
        {
            LessonEntity isSuccess = _lessonService.UpdateItem(id, value);
            if (isSuccess != null)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<LessonController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool isSuccess = _lessonService.DeleteItem(id);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }


    }
}
