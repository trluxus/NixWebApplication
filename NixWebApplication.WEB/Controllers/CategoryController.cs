using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NixWebApplication.BLL.DTO;
using NixWebApplication.BLL.Interfaces;
using NixWebApplication.DAL.Entities;
using NixWebApplication.Models;
using NixWebApplication.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NixWebApplication.WEB.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryController(ICategoryService service, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this._service = service;
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
        }

        // GET: CategoryController
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
            ViewData["BedsSortParm"] = sortOrder == "Beds" ? "beds_desc" : "Beds";

            ViewData["CurrentFilter"] = searchString;

            var data = _service.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                data = data.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    data = data.OrderByDescending(s => s.Name);
                    break;
                case "Beds":
                    data = data.OrderBy(s => s.Beds);
                    break;
                case "beds_desc":
                    data = data.OrderByDescending(s => s.Beds);
                    break;
                default:
                    data = data.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 3;
            return View(PaginatedList<CategoryModel>.
                Create(_mapper.Map<IEnumerable<CategoryDTO>, List<CategoryModel>>(data), pageNumber ?? 1, pageSize));
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var data = _service.Get(id);
            return View(_mapper.Map<CategoryDTO, CategoryModel>(data));
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(nameof(CategoryModel.Id), nameof(CategoryModel.Name),
            nameof(CategoryModel.Beds), nameof(CategoryModel.ApplicationUser),
            nameof(CategoryModel.TimeStamp))] CategoryModel data)
        {
            if (ModelState.IsValid)
            {
                data.ApplicationUser = new() { Id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) };
                data.TimeStamp = DateTime.Now;

                _service.Create(_mapper.Map<CategoryModel, CategoryDTO>(data));
                return RedirectToAction(nameof(Index));
            }
            return View(data);
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = _service.Get(id.Value);
            if (data == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<CategoryDTO, CategoryModel>(data));
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, 
            [Bind(nameof(CategoryModel.Id), nameof(CategoryModel.Name),
            nameof(CategoryModel.Beds), nameof(CategoryModel.ApplicationUser),
            nameof(CategoryModel.TimeStamp))] CategoryModel data)
        {
            if (id != data.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                data.ApplicationUser = new() { Id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) };
                data.TimeStamp = DateTime.Now;

                _service.Update(_mapper.Map<CategoryModel, CategoryDTO>(data));
                return RedirectToAction(nameof(Index));
            }
            return View(data);
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = _service.Get(id.Value);

            if (data == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<CategoryDTO, CategoryModel>(data));
        }

        // POST: CategoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
