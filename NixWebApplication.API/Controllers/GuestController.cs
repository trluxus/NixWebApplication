using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NixWebApplication.API.Models;
using NixWebApplication.BLL.DTO;
using NixWebApplication.BLL.Interfaces;
using NixWebApplication.BLL.Services;
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
        private IGuestService service;
        private IMapper mapper;

        public GuestController(IGuestService service)
        {
            this.service = service;

            mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<GuestDTO, GuestModel>()).CreateMapper();
        }

        // GET: api/<GuestController>
        [HttpGet]
        public IEnumerable<GuestModel> Get()
        {
            var data = service.GetAll();

            var guests = mapper.Map<IEnumerable<GuestDTO>, List<GuestModel>>(data);
            return guests;
        }

        // GET api/<GuestController>/5
        [HttpGet("{id}")]
        public ActionResult<GuestModel> Get(int id)
        {
            try
            {
                GuestDTO data = service.Get(id);
                var guest = new GuestModel();

                if (data != null)
                {
                    guest = mapper.Map<GuestDTO, GuestModel>(data);
                }

                return Ok(guest);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex);
            }
        }

        // POST api/<GuestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GuestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GuestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
