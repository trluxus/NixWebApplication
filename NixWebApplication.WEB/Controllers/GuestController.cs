using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NixWebApplication.BLL.DTO;
using NixWebApplication.BLL.Interfaces;
using NixWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixWebApplication.WEB.Controllers
{
    public class GuestController : Controller
    {
        private readonly IGuestService _service;
        private readonly IMapper _mapper;

        public GuestController(IGuestService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        // GET: GuestController
        public ActionResult Index()
        {
            var data = _service.GetAll();
            return View(_mapper.Map<IEnumerable<GuestDTO>, List<GuestModel>>(data));
        }

        // GET: GuestController/Details/5
        public ActionResult Details(int id)
        {
            var data = _service.Get(id);
            return View(_mapper.Map<GuestDTO, GuestModel>(data));
        }

        // GET: GuestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GuestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GuestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GuestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GuestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GuestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
