using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NixWebApplication.API.Models;
using NixWebApplication.BLL.DTO;
using NixWebApplication.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NixWebApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<CategoryModel> Get()
        {
            var data = _service.GetAll();
            return _mapper.Map<IEnumerable<CategoryDTO>, List<CategoryModel>>(data);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public CategoryModel Get(int id)
        {
            try
            {
                var data = _service.Get(id);

                if (data == null)
                    throw new NullReferenceException();

                return _mapper.Map<CategoryDTO, CategoryModel>(data);
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] CategoryModel category)
        {
            _service.Create(_mapper.Map<CategoryModel, CategoryDTO>(category));
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
