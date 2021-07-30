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

namespace NixWebApplication.Tests.API
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

        [Test]
        public void Get()
        {
            _mock.Setup(a => a.GetAll()).Returns(new List<GuestDTO>());

            var expected = _mapper.Map<IEnumerable<GuestDTO>, List<GuestModel>>(_mock.Object.GetAll());
            var result = _guestController.Get();

            Assert.IsInstanceOf(typeof(IEnumerable<GuestModel>), result);
            Assert.AreEqual(expected, result);
        }

        [TestCase(1)]
        public void Get(int id)
        {
            _mock.Setup(a => a.Get(id)).Returns(new GuestDTO() { Id = id });

            var expected = _mapper.Map<GuestDTO, GuestModel>(_mock.Object.Get(id));
            var result = _guestController.Get(id);

            Assert.IsInstanceOf(typeof(GuestModel), result);
            Assert.AreEqual(expected, result);
        }
    }
}
