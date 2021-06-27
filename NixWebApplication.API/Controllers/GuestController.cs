﻿using AutoMapper;
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
        private readonly IMapper mapper;

        public GuestController(IGuestService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        // GET: api/<GuestController>
        [HttpGet]
        public ActionResult<GuestModel> Get()
        {
            var data = service.GetAll();
            var guests = mapper.Map<IEnumerable<GuestDTO>, List<GuestModel>>(data);

            return Ok(guests);
        }

        // GET api/<GuestController>/5
        [HttpGet("{id}")]
        public ActionResult<GuestModel> Get(int id)
        {
            try
            {
                var data = service.Get(id);

                if (data == null)
                    throw new NullReferenceException();

                var guest = mapper.Map<GuestDTO, GuestModel>(data);

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
            service.Create(mapper.Map<GuestModel, GuestDTO>(guest));

            return Ok(guest);
        }
    }
}