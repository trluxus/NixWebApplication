using AutoMapper;
using Microsoft.AspNetCore.Http;
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
        private IRoomService service;
        private readonly IMapper mapper;

        public RoomController(IRoomService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        // GET: api/<RoomController>
        [HttpGet]
        public ActionResult<RoomModel> Get()
        {
            var data = service.GetAll();

            var rooms = mapper.Map<IEnumerable<RoomDTO>, List<RoomModel>>(data);
            return Ok(rooms);
        }

        // GET api/<RoomController>/5
        [HttpGet("{id}")]
        public ActionResult<RoomModel> Get(int id)
        {
            try
            {
                var data = service.Get(id);

                if (data == null)
                    throw new NullReferenceException();

                var room = new RoomModel();
                
                room = mapper.Map<RoomDTO, RoomModel>(data);


                return Ok(room);
            }
            catch (NullReferenceException ex)
            {
                return NotFound();
            }
        }

        // POST api/<RoomController>
        [HttpPost]
        public ActionResult<RoomModel> Build(RoomModel room)
        {
            service.Create(mapper.Map<RoomModel, RoomDTO>(room));

            return Ok(room);
        }

        // Get api/<RoomController>/
        [HttpGet, Route("empty")]
        public ActionResult<RoomModel> FindEmpty([FromBody]DateTime startDate, DateTime endDate)
        {
            var data = service.FindEmpty(startDate, endDate);

            var res = mapper.Map<IEnumerable<RoomDTO>, List<RoomModel>>(data);

            return Ok(res);
        }
    }
}
