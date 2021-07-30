using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NixWebApplication.API.Models;
using NixWebApplication.BLL.DTO;
using NixWebApplication.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixWebApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;
        private readonly IMapper _mapper;

        public RoomController(IRoomService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
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
        [HttpGet("empty/{startDate}/{endDate}"), Route("empty")]
        public IEnumerable<RoomModel> FindEmpty(string startDate, string endDate)
        {
            var data = _service.FindEmpty(DateTime.Parse(startDate), DateTime.Parse(endDate));
            return _mapper.Map<IEnumerable<RoomDTO>, List<RoomModel>>(data);
        }

        // POST api/<RoomController>
        [HttpPost]
        public void Post(RoomModel room)
        {
            _service.Create(_mapper.Map<RoomModel, RoomDTO>(room));
        }

        // PUT api/<RoomController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RoomController>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }        
    }
}
