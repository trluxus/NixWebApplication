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
    public class PriceToCategoryController : Controller
    {
        private readonly IPriceToCategoryService _service;
        private readonly IMapper _mapper;

        public PriceToCategoryController(IPriceToCategoryService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        // GET: PriceToCategoryController
        public ActionResult Index()
        {
            var data = _service.GetAll();
            return View(_mapper.Map<IEnumerable<PriceToCategoryDTO>, List<PriceToCategoryModel>>(data));
        }

        // GET: PriceToCategoryController/Details/5
        public ActionResult Details(int id)
        {
            var data = _service.Get(id);
            return View(_mapper.Map<PriceToCategoryDTO, PriceToCategoryModel>(data));
        }

        // GET: PriceToCategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PriceToCategoryController/Create
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

        // GET: PriceToCategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PriceToCategoryController/Edit/5
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

        // GET: PriceToCategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PriceToCategoryController/Delete/5
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
