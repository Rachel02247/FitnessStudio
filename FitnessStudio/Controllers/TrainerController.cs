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
    public class TrainerController : ControllerBase
    {
        //private object result;
        readonly IService2<TrainerEntity> _trainerService;
        public TrainerController(IService2<TrainerEntity> trainerService)
        {
            _trainerService = trainerService;
        }
        // GET: api/<TrainerController>
        [HttpGet]
        public ActionResult<List<TrainerEntity>>? Get()
        {
            return _trainerService.GetAll();
        }

        // GET api/<TrainerController>/5
        [HttpGet("{id}")]
        public ActionResult<TrainerEntity> GetById(string id)
        {
            if (id == null)
                return BadRequest();
            var Trainer = _trainerService.GetByID(id);
            if (Trainer == null)
                return NotFound();
            return Trainer;
        }
        // POST api/<TrainerController>
        [HttpPost]
        public ActionResult<TrainerEntity> Post([FromBody] TrainerEntity value)
        {
            TrainerEntity isSuccess = _trainerService.AddItem(value);
            if (isSuccess != null)
                return Ok(true);
            return BadRequest("ID exists in the system or the file do not found");
        }

        // PUT api/<TrainerController>/5
        [HttpPut("{id}")]
        public ActionResult<TrainerEntity> Put(string id, [FromBody] TrainerEntity value)
        {
            TrainerEntity isSuccess = _trainerService.UpdateItem(id, value);
            if (isSuccess != null)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<TrainerController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(string id)
        {
            bool isSuccess = _trainerService.DeleteItem(id);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }


    }
}
