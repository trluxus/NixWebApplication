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
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;
        private readonly IMapper _mapper;

        public BookingController(IBookingService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        // GET: api/<BookingController>
        [HttpGet]
        public IEnumerable<BookingModel> Get()
        {
            var data = _service.GetAll();
            return _mapper.Map<IEnumerable<BookingDTO>, List<BookingModel>>(data);
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public BookingModel Get(int id)
        {
            var data = _service.Get(id);
            return _mapper.Map<BookingDTO, BookingModel>(data);
        }

        // GET: api/<BookingController>/income/2020-01-20
        [HttpGet("income/{date}"), Route("income")]
        public decimal Income(string date)
        {
            return _service.Income(DateTime.Parse(date));
        }

        // POST api/<BookingController>
        [HttpPost]
        public void Post([FromBody] BookingModel booking)
        {
            _service.Create(_mapper.Map<BookingModel, BookingDTO>(booking));
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingController>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
