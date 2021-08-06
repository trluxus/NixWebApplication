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
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _service;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GuestController(IGuestService service, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this._service = service;
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
        }

        // GET: api/<GuestController>
        [HttpGet]
        public IEnumerable<GuestModel> Get()
        {
            var data = _service.GetAll();
            return _mapper.Map<IEnumerable<GuestDTO>, List<GuestModel>>(data);
        }

        // GET api/<GuestController>/5
        [HttpGet("{id}")]
        public GuestModel Get(int id)
        {
            var data = _service.Get(id);
            return _mapper.Map<GuestDTO, GuestModel>(data);
        }

        // POST api/<GuestController>
        [HttpPost]
        public void Post([FromBody] GuestModel guest)
        {
            guest.ApplicationUser = new() { Id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) };
            guest.TimeStamp = DateTime.Now;

            _service.Create(_mapper.Map<GuestModel, GuestDTO>(guest));
        }

        // PUT api/<GuestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] GuestModel guest)
        {
            guest.ApplicationUser = new() { Id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) };
            guest.TimeStamp = DateTime.Now;

            _service.Update(_mapper.Map<GuestModel, GuestDTO>(guest));
        }

        // DELETE api/<GuestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
