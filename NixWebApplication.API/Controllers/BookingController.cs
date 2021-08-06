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
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BookingController(IBookingService service, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this._service = service;
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
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
            booking.ApplicationUser = new() { Id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) };
            booking.TimeStamp = DateTime.Now;

            _service.Create(_mapper.Map<BookingModel, BookingDTO>(booking));
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BookingModel booking)
        {
            booking.ApplicationUser = new() { Id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) };
            booking.TimeStamp = DateTime.Now;

            _service.Update(_mapper.Map<BookingModel, BookingDTO>(booking));
        }

        // DELETE api/<BookingController>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
