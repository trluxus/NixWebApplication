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
    class CategoryControllerTest
    {
        private CategoryController _categoryController;
        private Mock<ICategoryService> _mock;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<ICategoryService>();

            _mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<CategoryDTO, CategoryModel>())
                .CreateMapper();

            _categoryController = new CategoryController(_mock.Object, _mapper);
        }

        [Test]
        public void Get()
        {
            _mock.Setup(a => a.GetAll()).Returns(new List<CategoryDTO>());

            var expected = _mapper.Map<IEnumerable<CategoryDTO>, List<CategoryModel>>(_mock.Object.GetAll());
            var result = _categoryController.Get();

            Assert.IsInstanceOf(typeof(IEnumerable<CategoryModel>), result);
            Assert.AreEqual(expected, result);
        }

        [TestCase(1)]
        public void Get(int id)
        {
            _mock.Setup(a => a.Get(id)).Returns(new CategoryDTO() { Id = id });

            var expected = _mapper.Map<CategoryDTO, CategoryModel>(_mock.Object.Get(id));
            var result = _categoryController.Get(id);

            Assert.IsInstanceOf(typeof(CategoryModel), result);
            Assert.AreEqual(expected, result);
        }
    }
}
