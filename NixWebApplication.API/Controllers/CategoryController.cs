using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NixWebApplication.BLL.DTO;
using NixWebApplication.BLL.Interfaces;
using NixWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryController(ICategoryService service, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this._service = service;
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
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
            var data = _service.Get(id);
            return _mapper.Map<CategoryDTO, CategoryModel>(data);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] CategoryModel category)
        {
            category.ApplicationUser = new() { Id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) };
            category.TimeStamp = DateTime.Now;

            _service.Create(_mapper.Map<CategoryModel, CategoryDTO>(category));
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CategoryModel category)
        {
            category.ApplicationUser = new() { Id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) };
            category.TimeStamp = DateTime.Now;

            _service.Update(_mapper.Map<CategoryModel, CategoryDTO>(category));
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
