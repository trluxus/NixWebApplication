using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NixWebApplication.API.Controllers;
using NixWebApplication.API.Models;
using NixWebApplication.BLL.DTO;
using NixWebApplication.BLL.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NixWebApplication.Tests
{
    [TestFixture]
    public class GuestControllerTest
    {
        private GuestController _guestController;
        private Mock<IGuestService> _mock;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IGuestService>();

            _mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<GuestDTO, GuestModel>())
                .CreateMapper();

            _guestController = new GuestController(_mock.Object, _mapper);
        }

        [TestCase(1)]
        public void Get(int id)
        {
            _mock.Setup(a => a.Get(id)).Returns(new GuestDTO());

            var expected = _mapper.Map<GuestDTO, GuestModel>(_mock.Object.Get(id));

            var actionResult = _guestController.Get(id).Result;

            Assert.IsInstanceOf(typeof(OkObjectResult), actionResult);

            var result = actionResult as OkObjectResult;

            Assert.IsInstanceOf(typeof(GuestModel), result.Value);
            Assert.AreEqual(expected, result.Value);
        }
        
        [Test]
        public void GetAll()
        {
            _mock.Setup(a => a.GetAll()).Returns(new List<GuestDTO>());

            var expected = _mapper.Map<IEnumerable<GuestDTO>, List<GuestModel>>(_mock.Object.GetAll());

            var actionResult = _guestController.GetAll().Result;

            Assert.IsInstanceOf(typeof(OkObjectResult), actionResult);

            var result = actionResult as OkObjectResult;

            Assert.IsInstanceOf(typeof(IEnumerable<GuestModel>), result.Value);
            Assert.AreEqual(expected, result.Value);
        }
    }
}
