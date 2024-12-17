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
    public class TrainerController : ControllerBase
    {
        //private object result;
        readonly ITrainerService _trainerService;
        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }
        // GET: api/<TrainerController>
        [HttpGet]
        public ActionResult<List<TrainerEntity>> Get()
        {
            return _trainerService.GetAll();
        }

        // GET api/<TrainerController>/5
        [HttpGet("{id}")]
        public ActionResult<TrainerEntity> GetById(int id)
        {
            if (id < 0)
                return BadRequest();
            var trainer = _trainerService.GetByID(id);
            if (trainer == null)
                return NotFound();
            return trainer;
        }
        // POST api/<TrainerController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] TrainerEntity value)
        {
            bool isSuccess = _trainerService.AddTrainer(value);
            if (isSuccess)
                return Ok(true);
            return BadRequest("ID exists in the system or the file do not found");

        }

        // PUT api/<TrainerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TrainerEntity value)
        {
            bool isSuccess = _trainerService.UpdateTrainer(id, value);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<TrainerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool isSuccess = _trainerService.DeleteTrainer(id);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }


    }
}
