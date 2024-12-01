//using FitnessProject.Entities;
//using FitnessProject.Services;
//using Microsoft.AspNetCore.Cors.Infrastructure;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace FitnessProject.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LessonController : ControllerBase
//    {
//        readonly GymnastService _gymnastService;
//        //private object result;
//        public LessonController()
//        {
//            _gymnastService = new GymnastService();
//        }
//        // GET: api/<LessonController>
//        [HttpGet]
//        public ActionResult<List<GymnastEntity>> Get()
//        {
//            List<GymnastEntity> result = _gymnastService.GymnastList;
//            if (result == null)
//                return Unauthorized();
//            return result;
//        }

//        // POST api/<LessonController>
//        [HttpPost]
//        public ActionResult<bool> Post([FromBody] GymnastEntity value)
//        {
//            return _gymnastService.AddGymnast(value);
//        }

//        // PUT api/<LessonController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] GymnastEntity value)
//        {
//            _gymnastService.UpdateGymnast(id, value);
//        }

//        // DELETE api/<LessonController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//            GymnastEntity current = _gymnastService.GetByID(id);
//          //  _gymnastService.GymnastList.Remove(current);
//        }
//    }
//}
