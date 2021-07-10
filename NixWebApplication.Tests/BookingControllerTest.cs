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
    class BookingControllerTest
    {
        private BookingController _bookingController;
        private Mock<IBookingService> _mock;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IBookingService>();

            _mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<BookingDTO, BookingModel>())
                .CreateMapper();

            _bookingController = new BookingController(_mock.Object, _mapper);
        }

        [TestCase(1)]
        public void Get(int id)
        {
            _mock.Setup(a => a.Get(id)).Returns(new BookingDTO());

            var expected = _mapper.Map<BookingDTO, BookingModel>(_mock.Object.Get(id));

            var actionResult = _bookingController.Get(id).Result;

            Assert.IsInstanceOf(typeof(OkObjectResult), actionResult);

            var result = actionResult as OkObjectResult;

            Assert.IsInstanceOf(typeof(BookingModel), result.Value);
            Assert.AreEqual(expected, result.Value);
        }

        [Test]
        public void GetAll()
        {
            _mock.Setup(a => a.GetAll()).Returns(new List<BookingDTO>());

            var expected = _mapper.Map<IEnumerable<BookingDTO>, List<BookingModel>>(_mock.Object.GetAll());

            var actionResult = _bookingController.GetAll().Result;

            Assert.IsInstanceOf(typeof(OkObjectResult), actionResult);

            var result = actionResult as OkObjectResult;

            Assert.IsInstanceOf(typeof(IEnumerable<BookingModel>), result.Value);
            Assert.AreEqual(expected, result.Value);
        }

    }
}
