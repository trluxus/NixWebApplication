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
    public class PriceToCategoryController : ControllerBase
    {
        private readonly IPriceToCategoryService _service;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PriceToCategoryController(IPriceToCategoryService service, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this._service = service;
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
        }

        // GET: api/<PriceToCategoryController>
        [HttpGet]
        public IEnumerable<PriceToCategoryModel> Get()
        {
            var data = _service.GetAll();
            return _mapper.Map<IEnumerable<PriceToCategoryDTO>, List<PriceToCategoryModel>>(data);
        }

        // GET api/<PriceToCategoryController>/5
        [HttpGet("{id}")]
        public PriceToCategoryModel Get(int id)
        {
            var data = _service.Get(id);
            return _mapper.Map<PriceToCategoryDTO, PriceToCategoryModel>(data);
        }

        // POST api/<PriceToCategoryController>
        [HttpPost]
        public void Post([FromBody] PriceToCategoryModel priceToCategory)
        {
            priceToCategory.ApplicationUser = new() { Id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) };
            priceToCategory.TimeStamp = DateTime.Now;

            _service.Create(_mapper.Map<PriceToCategoryModel, PriceToCategoryDTO>(priceToCategory));
        }

        // PUT api/<PriceToCategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PriceToCategoryModel priceToCategory)
        {
            priceToCategory.ApplicationUser = new() { Id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) };
            priceToCategory.TimeStamp = DateTime.Now;

            _service.Update(_mapper.Map<PriceToCategoryModel, PriceToCategoryDTO>(priceToCategory));
        }

        // DELETE api/<PriceToCategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
