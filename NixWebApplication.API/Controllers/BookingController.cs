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
        private IMapper mapper;

        public BookingController(IBookingService service)
        {
            this.service = service;

            mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<BookingDTO, BookingModel>()).CreateMapper();
        }

        // GET: api/<GuestController>
        [HttpGet]
        public IEnumerable<BookingModel> Get()
        {
            var data = service.GetAll();

            var bookings = mapper.Map<IEnumerable<BookingDTO>, List<BookingModel>>(data);
            return bookings;
        }

        // GET api/<GuestController>/5
        [HttpGet("{id}")]
        public ActionResult<BookingModel> Get(int id)
        {
            try
            {
                BookingDTO data = service.Get(id);
                var booking = new BookingModel();

                if (data != null)
                {
                    booking = mapper.Map<BookingDTO, BookingModel>(data);
                }

                return Ok(booking);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex);
            }
        }
    }
}
