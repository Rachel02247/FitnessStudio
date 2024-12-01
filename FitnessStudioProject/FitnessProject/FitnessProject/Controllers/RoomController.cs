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
    public class RoomController : ControllerBase
    {
        readonly RoomService _roomService;
        //private object result;
        public RoomController()
        {
            _roomService = new RoomService();
        }
        // GET: api/<RoomController>
        [HttpGet]
        public ActionResult<List<RoomEntity>> Get()
        {
            List<RoomEntity> result = _roomService.RoomList;
            if (result == null)
                return Unauthorized();
            return result;
        }

        // POST api/<RoomController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] RoomEntity value)
        {
            return _roomService.AddRoom(value);
        }

        // PUT api/<RoomController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] RoomEntity value)
        {
            _roomService.UpdateRoom(id, value);
        }

        // DELETE api/<RoomController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            RoomEntity current = _roomService.getID(id);
            _roomService.RoomList.Remove(current);
        }
    }
}
