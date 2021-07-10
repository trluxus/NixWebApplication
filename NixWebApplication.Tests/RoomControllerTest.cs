using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NixWebApplication.API.Controllers;
using NixWebApplication.API.Models;
using NixWebApplication.BLL.DTO;
using NixWebApplication.BLL.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixWebApplication.Tests
{
    [TestFixture]
    class RoomControllerTest
    {
        private RoomController _roomController;
        private Mock<IRoomService> _mock;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IRoomService>();

            _mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<RoomDTO, RoomModel>())
                .CreateMapper();

            _roomController = new RoomController(_mock.Object, _mapper);
        }

        [TestCase(1)]
        public void Get(int id)
        {
            _mock.Setup(a => a.Get(id)).Returns(new RoomDTO());

            var expected = _mapper.Map<RoomDTO, RoomModel>(_mock.Object.Get(id));

            var actionResult = _roomController.Get(id).Result;

            Assert.IsInstanceOf(typeof(OkObjectResult), actionResult);

            var result = actionResult as OkObjectResult;

            Assert.IsInstanceOf(typeof(RoomModel), result.Value);
            Assert.AreEqual(expected, result.Value);
        }

        [Test]
        public void GetAll()
        {
            _mock.Setup(a => a.GetAll()).Returns(new List<RoomDTO>());

            var expected = _mapper.Map<IEnumerable<RoomDTO>, List<RoomModel>>(_mock.Object.GetAll());

            var actionResult = _roomController.GetAll().Result;

            Assert.IsInstanceOf(typeof(OkObjectResult), actionResult);

            var result = actionResult as OkObjectResult;

            Assert.IsInstanceOf(typeof(IEnumerable<RoomModel>), result.Value);
            Assert.AreEqual(expected, result.Value);
        }
    }
}
