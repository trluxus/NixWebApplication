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
        private IMapper mapper;

        public RoomController(IRoomService service)
        {
            this.service = service;

            mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<RoomDTO, RoomModel>()).CreateMapper();
        }

        // GET: api/<GuestController>
        [HttpGet]
        public IEnumerable<RoomModel> Get()
        {
            var data = service.GetAll();

            var rooms = mapper.Map<IEnumerable<RoomDTO>, List<RoomModel>>(data);
            return rooms;
        }

        // GET api/<GuestController>/5
        [HttpGet("{id}")]
        public ActionResult<RoomModel> Get(int id)
        {
            try
            {
                RoomDTO data = service.Get(id);
                var room = new RoomModel();

                if (data != null)
                {
                    room = mapper.Map<RoomDTO, RoomModel>(data);
                }

                return Ok(room);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex);
            }
        }
    }
}
