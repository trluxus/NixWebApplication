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

namespace NixWebApplication.Tests.API
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

        [Test]
        public void GetAll()
        {
            _mock.Setup(a => a.GetAll()).Returns(new List<RoomDTO>());

            var expected = _mapper.Map<IEnumerable<RoomDTO>, List<RoomModel>>(_mock.Object.GetAll());
            var result = _roomController.Get();

            Assert.IsInstanceOf(typeof(IEnumerable<RoomModel>), result);
            Assert.AreEqual(expected, result);
        }

        [TestCase(1)]
        public void Get(int id)
        {
            _mock.Setup(a => a.Get(id)).Returns(new RoomDTO() { Id = id });

            var expected = _mapper.Map<RoomDTO, RoomModel>(_mock.Object.Get(id));
            var result = _roomController.Get(id);

            Assert.IsInstanceOf(typeof(RoomModel), result);
            Assert.AreEqual(expected, result);
        }
    }
}
