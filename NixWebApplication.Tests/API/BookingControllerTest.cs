using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NixWebApplication.API.Controllers;
using NixWebApplication.BLL.DTO;
using NixWebApplication.BLL.Interfaces;
using NixWebApplication.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixWebApplication.Tests.API
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

        [Test]
        public void Get()
        {
            _mock.Setup(a => a.GetAll()).Returns(new List<BookingDTO>());

            var expected = _mapper.Map<IEnumerable<BookingDTO>, List<BookingModel>>(_mock.Object.GetAll());
            var result = _bookingController.Get();

            Assert.IsInstanceOf(typeof(IEnumerable<BookingModel>), result);
            Assert.AreEqual(expected, result);
        }

        [TestCase(1)]
        public void Get(int id)
        {
            _mock.Setup(a => a.Get(id)).Returns(new BookingDTO() { Id = id });

            var expected = _mapper.Map<BookingDTO, BookingModel>(_mock.Object.Get(id));
            var result = _bookingController.Get(id);

            Assert.IsInstanceOf(typeof(BookingModel), result);
            Assert.AreEqual(expected, result);
        }
    }
}
