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
    public class RoomController : ControllerBase
    {
        //private object result;
        readonly IService2<RoomEntity> _roomService;
        public RoomController(IService2<RoomEntity> roomService)
        {
            _roomService = roomService;
        }
        // GET: api/<RoomController>
        [HttpGet]
        public ActionResult<List<RoomEntity>>? Get()
        {
            return _roomService.GetAll();
        }

        // GET api/<RoomController>/5
        [HttpGet("{id}")]
        public ActionResult<RoomEntity> GetById(string id)
        {
            if (id == null)
                return BadRequest();
            var Room = _roomService.GetByID(id);
            if (Room == null)
                return NotFound();
            return Room;
        }
        // POST api/<RoomController>
        [HttpPost]
        public ActionResult<RoomEntity> Post([FromBody] RoomEntity value)
        {
            RoomEntity isSuccess = _roomService.AddItem(value);
            if (isSuccess != null)
                return Ok(true);
            return BadRequest("ID exists in the system or the file do not found");
        }

        // PUT api/<RoomController>/5
        [HttpPut("{id}")]
        public ActionResult<RoomEntity> Put(string id, [FromBody] RoomEntity value)
        {
            RoomEntity isSuccess = _roomService.UpdateItem(id, value);
            if (isSuccess != null)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<RoomController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(string id)
        {
            bool isSuccess = _roomService.DeleteItem(id);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }


    }
}
