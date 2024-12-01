using FitnessProject.Controllers;
using FitnessProject.Entities;
using FitnessProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastControllerTests
{
    public class GymnastControllerTests
    {
        [Fact]
        public void GetAll_ReturnsOK()
        {
            //arrange

            //act
            var controller = new GymnastController(new GymnastService(new DataContextGymnastFake())).Get();
            //assert
            Assert.IsType<ActionResult<List<GymnastEntity>>>(controller);
        }
        [Fact]
        public void GetById_ReturnsNotFound()
        {
            //arrange
            var id = 4;
            //act
            var controller = new GymnastController(new GymnastService(new DataContextGymnastFake())).GetById(id);
            //assert
            Assert.IsType<NotFoundResult>(controller);
        }
        public void GetById_ReturnsBadRequest()
        {
            //arrange
            var id = -1;
            //act
            var controller = new GymnastController(new GymnastService(new DataContextGymnastFake())).GetById(id);
            //assert
            Assert.IsType<BadRequestResult>(controller);
        }
        public void GetById_ReturnsOK()
        {
            //arrange
            var id = 1;
            //act
            var controller = new GymnastController(new GymnastService(new DataContextGymnastFake())).GetById(id);
            //assert
            Assert.IsType<ActionResult<GymnastEntity>>(controller);
        }
    }
}
