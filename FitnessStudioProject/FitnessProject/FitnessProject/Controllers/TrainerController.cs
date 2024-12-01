using FitnessProject.Entities;
using FitnessProject.Services;
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
        readonly TrainerService _trainerService;
        //private object result;
        public TrainerController()
        {
            _trainerService = new TrainerService();
        }
        // GET: api/<TrainerController>
        [HttpGet]
        public ActionResult<List<TrainerEntity>> Get()
        {
            List<TrainerEntity> result = _trainerService.TrainerList;
            if (result == null)
                return Unauthorized();
            return result;
        }

        // POST api/<TrainerController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] TrainerEntity value)
        {
            return _trainerService.AddTrainer(value);
        }

        // PUT api/<TrainerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TrainerEntity value)
        {
            _trainerService.UpdateTrainer(id, value);
        }

        // DELETE api/<TrainerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            TrainerEntity current = _trainerService.getID(id);
            _trainerService.TrainerList.Remove(current);
        }
    }
}
