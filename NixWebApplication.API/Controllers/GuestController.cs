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
    public class GuestController : ControllerBase
    {
        private IGuestService _service;
        private readonly IMapper _mapper;

        public GuestController(IGuestService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        // GET: api/<GuestController>
        [HttpGet]
        public ActionResult<GuestModel> Get()
        {
            var data = _service.GetAll();
            var guests = _mapper.Map<IEnumerable<GuestDTO>, List<GuestModel>>(data);

            return Ok(guests);
        }

        // GET api/<GuestController>/5
        [HttpGet("{id}")]
        public ActionResult<GuestModel> Get(int id)
        {
            try
            {
                var data = _service.Get(id);

                if (data == null)
                    throw new NullReferenceException();

                var guest = _mapper.Map<GuestDTO, GuestModel>(data);

                return Ok(guest);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        // POST api/<GuestController>
        [HttpPost]
        public ActionResult<GuestModel> Register(GuestModel guest)
        {
            _service.Create(_mapper.Map<GuestModel, GuestDTO>(guest));

            return Ok(guest);
        }
    }
}
