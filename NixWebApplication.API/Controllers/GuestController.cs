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
        private readonly IGuestService _service;
        private readonly IMapper _mapper;

        public GuestController(IGuestService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
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
            _service.Create(_mapper.Map<GuestModel, GuestDTO>(guest));
        }

        // PUT api/<GuestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] GuestModel guest)
        {
        }

        // DELETE api/<GuestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
