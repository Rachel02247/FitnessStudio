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
    public class RoomController : ControllerBase
    {
        //private object result;
        readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        // GET: api/<RoomController>
        [HttpGet]
        public ActionResult<List<RoomEntity>> Get()
        {
            return _roomService.GetAll();
        }

        // GET api/<RoomController>/5
        [HttpGet("{id}")]
        public ActionResult<RoomEntity> GetById(int id)
        {
            if (id < 0)
                return BadRequest();
            var room = _roomService.GetByID(id);
            if (room == null)
                return NotFound();
            return room;
        }
        // POST api/<RoomController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] RoomEntity value)
        {
            bool isSuccess = _roomService.AddRoom(value);
            if (isSuccess)
                return Ok(true);
            return BadRequest("ID exists in the system or the file do not found");

        }

        // PUT api/<RoomController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] RoomEntity value)
        {
            bool isSuccess = _roomService.UpdateRoom(id, value);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<RoomController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool isSuccess = _roomService.DeleteRoom(id);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }


    }
}
