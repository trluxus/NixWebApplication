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

namespace NixWebApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RoomController(IRoomService service, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this._service = service;
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
        }

        // GET: api/<RoomController>
        [HttpGet]
        public IEnumerable<RoomModel> Get()
        {
            var data = _service.GetAll();
            return _mapper.Map<IEnumerable<RoomDTO>, List<RoomModel>>(data);
        }

        // GET api/<RoomController>/5
        [HttpGet("{id}")]
        public RoomModel Get(int id)
        {
            var data = _service.Get(id);
            return _mapper.Map<RoomDTO, RoomModel>(data);
        }

        // GET: api/<RoomController>/empty/2020-01-20/2020-03-16
        [HttpGet("emptyAPI/{startDate}/{endDate}")]
        public IEnumerable<RoomModel> FindEmpty(string startDate, string endDate)
        {
            var data = _service.FindEmpty(DateTime.Parse(startDate), DateTime.Parse(endDate));
            return _mapper.Map<IEnumerable<RoomDTO>, List<RoomModel>>(data);
        }

        // POST api/<RoomController>
        [HttpPost]
        public void Post(RoomModel room)
        {
            room.ApplicationUser = new() { Id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) };
            room.TimeStamp = DateTime.Now;

            _service.Create(_mapper.Map<RoomModel, RoomDTO>(room));
        }

        // PUT api/<RoomController>/5
        [HttpPut("{id}")]
        public void Put(int id, RoomModel room)
        {
            room.ApplicationUser = new() { Id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) };
            room.TimeStamp = DateTime.Now;

            _service.Update(_mapper.Map<RoomModel, RoomDTO>(room));
        }

        // DELETE api/<RoomController>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }        
    }
}
