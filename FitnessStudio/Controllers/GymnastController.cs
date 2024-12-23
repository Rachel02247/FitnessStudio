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
    public class GymnastController : ControllerBase
    {
        //private object result;
        readonly IService2<GymnastEntity> _gymnastService;
        public GymnastController(IService2<GymnastEntity> gymnastService)
        {
            _gymnastService = gymnastService;
        }
        // GET: api/<GymnastController>
        [HttpGet]
        public ActionResult<List<GymnastEntity>>? Get()
        {
            return _gymnastService.GetAll();
        }

        // GET api/<GymnastController>/5
        [HttpGet("{id}")]
        public ActionResult<GymnastEntity> GetById(string id)
        {
            if (id == null)
                return BadRequest();
            var Gymnast = _gymnastService.GetByID(id);
            if (Gymnast == null)
                return NotFound();
            return Gymnast;
        }
        // POST api/<GymnastController>
        [HttpPost]
        public ActionResult<GymnastEntity> Post([FromBody] GymnastEntity value)
        {
            GymnastEntity isSuccess = _gymnastService.AddItem(value);
            if (isSuccess != null)
                return Ok(true);
            return BadRequest("ID exists in the system or the file do not found");
        }

        // PUT api/<GymnastController>/5
        [HttpPut("{id}")]
        public ActionResult<GymnastEntity> Put(string id, [FromBody] GymnastEntity value)
        {
            GymnastEntity isSuccess = _gymnastService.UpdateItem(id, value);
            if (isSuccess != null)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<GymnastController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(string id)
        {
            bool isSuccess = _gymnastService.DeleteItem(id);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }


    }
}
