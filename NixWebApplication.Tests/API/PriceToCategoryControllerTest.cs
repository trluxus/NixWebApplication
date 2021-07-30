using AutoMapper;
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
    class PriceToCategoryControllerTest
    {
        private PriceToCategoryController _priceToCategoryController;
        private Mock<IPriceToCategoryService> _mock;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IPriceToCategoryService>();

            _mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<PriceToCategoryDTO, PriceToCategoryModel>())
                .CreateMapper();

            _priceToCategoryController = new PriceToCategoryController(_mock.Object, _mapper);
        }

        [Test]
        public void Get()
        {
            _mock.Setup(a => a.GetAll()).Returns(new List<PriceToCategoryDTO>());

            var expected = _mapper.Map<IEnumerable<PriceToCategoryDTO>, List<PriceToCategoryModel>>(_mock.Object.GetAll());
            var result = _priceToCategoryController.Get();

            Assert.IsInstanceOf(typeof(IEnumerable<PriceToCategoryModel>), result);
            Assert.AreEqual(expected, result);
        }

        [TestCase(1)]
        public void Get(int id)
        {
            _mock.Setup(a => a.Get(id)).Returns(new PriceToCategoryDTO() { Id = id });

            var expected = _mapper.Map<PriceToCategoryDTO, PriceToCategoryModel>(_mock.Object.Get(id));
            var result = _priceToCategoryController.Get(id);

            Assert.IsInstanceOf(typeof(PriceToCategoryModel), result);
            Assert.AreEqual(expected, result);
        }
    }
}
