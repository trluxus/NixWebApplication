﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NixWebApplication.BLL.DTO;
using NixWebApplication.BLL.Interfaces;
using NixWebApplication.Models;
using NixWebApplication.Pagination;
using NixWebApplication.WEB.Models.RoomViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixWebApplication.WEB.Controllers
{
    [Authorize]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public RoomController(IRoomService roomService, ICategoryService categoryService, IMapper mapper)
        {
            this._roomService = roomService;
            this._categoryService = categoryService;
            this._mapper = mapper;
        }

        // GET: RoomController
        public ActionResult Index(string sortOrder,
            string searchString,
            string currentFilter,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            ViewData["CurrentFilter"] = searchString;

            var data = _roomService.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                data = data.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    data = data.OrderByDescending(s => s.Name);
                break;
                default:
                    data = data.OrderBy(s => s.Name);
                break;
            }

            int pageSize = 3;
            return View(PaginatedList<RoomModel>.
                Create(_mapper.Map<IEnumerable<RoomDTO>, List<RoomModel>>(data), pageNumber ?? 1, pageSize));
        }

        // GET: RoomController/Details/5
        public ActionResult Details(int id)
        {
            var data = _roomService.Get(id);
            return View(_mapper.Map<RoomDTO, RoomModel>(data));
        }

        // GET: RoomController/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(),
                nameof(CategoryModel.Id), nameof(CategoryModel.Name), null);
            return View();
        }

        // POST: RoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Name,RoomCategory,IsActive")] RoomModel data)
        {
            if (ModelState.IsValid)
            {
                _roomService.Create(_mapper.Map<RoomModel, RoomDTO>(data));
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(),
                nameof(CategoryModel.Id), nameof(CategoryModel.Name), data.RoomCategory.Id);
            return View(data);
        }

        // GET: RoomController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = _roomService.Get(id.Value);

            if (data == null)
            {
                return NotFound();
            }
            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(),
                nameof(CategoryModel.Id), nameof(CategoryModel.Name), data.RoomCategory.Id);
            return View(_mapper.Map<RoomDTO, RoomModel>(data));
        }

        // POST: RoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Name,RoomCategory,IsActive")] RoomModel data)
        {
            if (id != data.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _roomService.Update(_mapper.Map<RoomModel, RoomDTO>(data));
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(),
                nameof(CategoryModel.Id), nameof(CategoryModel.Name), data.RoomCategory.Id);
            return View(data);
        }

        // GET: RoomController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = _roomService.Get(id.Value);

            if (data == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<RoomDTO, RoomModel>(data));
        }

        // POST: RoomController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _roomService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
