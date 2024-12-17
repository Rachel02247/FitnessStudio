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
    public class GymnastController : ControllerBase
    {        
        //private object result;
        readonly IGymnastService _gymnastService;
        public GymnastController(IGymnastService gymnastService)
        {
            _gymnastService = gymnastService;
        }
        // GET: api/<GymnastController>
        [HttpGet]
        public ActionResult<List<GymnastEntity>> Get()
        {
           return _gymnastService.GetAll();
        }

        // GET api/<GymnastController>/5
        [HttpGet("{id}")]
        public ActionResult<GymnastEntity> GetById(int id)
        {
            if (id < 0)
                return BadRequest();
            var gymnast = _gymnastService.GetByID(id);
            if(gymnast == null)
                return NotFound();
            return gymnast;
        }
        // POST api/<GymnastController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] GymnastEntity value)
        {
            bool isSuccess = _gymnastService.AddGymnast(value);
            if (isSuccess)
                return Ok(true);
            return BadRequest("ID exists in the system or the file do not found");
            
        }

        // PUT api/<GymnastController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] GymnastEntity value)
        {
            bool isSuccess = _gymnastService.UpdateGymnast(id, value);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<GymnastController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool isSuccess = _gymnastService.DeleteGymnast(id);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }


    }
}
