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

        // POST api/<RoomController>
        [HttpPost]
        public ActionResult<RoomModel> Create(RoomModel room)
        {
            _service.Create(_mapper.Map<RoomModel, RoomDTO>(room));

            return Ok(room);
        }

        // DELETE api/<RoomController>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }

        // GET api/<RoomController>/5
        [HttpGet("{id}")]
        public ActionResult<RoomModel> Get(int id)
        {
            try
            {
                var data = _service.Get(id);

                if (data == null)
                    throw new NullReferenceException();

                var room = new RoomModel();

                room = _mapper.Map<RoomDTO, RoomModel>(data);


                return Ok(room);
            }
            catch (NullReferenceException ex)
            {
                return NotFound();
            }
        }

        // GET: api/<RoomController>
        [HttpGet]
        public ActionResult<RoomModel> GetAll()
        {
            var data = _service.GetAll();

            var rooms = _mapper.Map<IEnumerable<RoomDTO>, List<RoomModel>>(data);
            return Ok(rooms);
        }

        // GET: api/<RoomController>/empty/2020-01-20/2020-03-16
        [HttpGet("empty/{startDate}/{endDate}"), Route("empty")]
        public ActionResult<RoomModel> FindEmpty(string startDate, string endDate)
        {
            var data = _service.FindEmpty(DateTime.Parse(startDate), DateTime.Parse(endDate));

            var res = _mapper.Map<IEnumerable<RoomDTO>, List<RoomModel>>(data);

            return Ok(res);
        }
    }
}
