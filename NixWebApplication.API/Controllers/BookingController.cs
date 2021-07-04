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
        public ActionResult<BookingModel> Get()
        {
            var data = _service.GetAll();

            var bookings = _mapper.Map<IEnumerable<BookingDTO>, List<BookingModel>>(data);
            return Ok(bookings);
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public ActionResult<BookingModel> Get(int id)
        {
            try
            {
                var data = _service.Get(id);

                if (data == null)
                    throw new NullReferenceException();

                var booking = new BookingModel();
                
                booking = _mapper.Map<BookingDTO, BookingModel>(data);

                return Ok(booking);
            }
            catch (NullReferenceException ex)
            {
                return NotFound();
            }
        }

        // POST api/<BookingController>
        [HttpPost]
        public ActionResult<BookingModel> Book(BookingModel booking)
        {
            _service.Create(_mapper.Map<BookingModel, BookingDTO>(booking));

            return Ok(booking);
        }

        // Get api/<BookingController>/
        [HttpGet("income/{date}"), Route("income")]
        public ActionResult<RoomModel> Income(string date)
        {
            var res = _service.Income(DateTime.Parse(date));

            return Ok(res);
        }
    }
}
