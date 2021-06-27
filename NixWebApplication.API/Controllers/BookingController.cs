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
    public class BookingController : ControllerBase
    {
        private IBookingService service;
        private readonly IMapper mapper;

        public BookingController(IBookingService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        // GET: api/<BookingController>
        [HttpGet]
        public ActionResult<BookingModel> Get()
        {
            var data = service.GetAll();

            var bookings = mapper.Map<IEnumerable<BookingDTO>, List<BookingModel>>(data);
            return Ok(bookings);
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public ActionResult<BookingModel> Get(int id)
        {
            try
            {
                var data = service.Get(id);

                if (data == null)
                    throw new NullReferenceException();

                var booking = new BookingModel();
                
                booking = mapper.Map<BookingDTO, BookingModel>(data);

                return Ok(booking);
            }
            catch (NullReferenceException ex)
            {
                return NotFound();
            }
        }

        // POST api/<BookingController>
        [HttpPost]
        public ActionResult<BookingModel> Build(BookingModel booking)
        {
            service.Create(mapper.Map<BookingModel, BookingDTO>(booking));

            return Ok(booking);
        }

        // Get api/<BookingController>/
        [HttpGet, Route("income")]
        public ActionResult<RoomModel> Income([FromBody] DateTime date)
        {
            var res = service.Income(date);

            return Ok(res);
        }
    }
}
