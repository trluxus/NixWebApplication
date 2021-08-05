using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NixWebApplication.BLL.DTO;
using NixWebApplication.BLL.Interfaces;
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
    public class GuestController : Controller
    {
        private readonly IGuestService _service;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GuestController(IGuestService service, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this._service = service;
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
        }

        // GET: GuestController
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

            ViewData["SurnameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "surname_desc" : "";
            ViewData["NameSortParm"] = sortOrder == "Name" ? "name_desc" : "Name";
            ViewData["PatronymicSortParm"] = sortOrder == "Patronymic" ? "patronymic_desc" : "Patronymic";

            ViewData["CurrentFilter"] = searchString;

            var data = _service.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                data = data.Where(s => s.Name.Contains(searchString)
                                       || s.Surname.Contains(searchString)
                                       || s.Patronymic.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "surname_desc":
                    data = data.OrderByDescending(s => s.Surname);
                    break;
                case "Name":
                    data = data.OrderBy(s => s.Name);
                    break;
                case "name_desc":
                    data = data.OrderByDescending(s => s.Name);
                    break;
                case "Patronymic":
                    data = data.OrderBy(s => s.Patronymic);
                    break;
                case "patronymic_desc":
                    data = data.OrderByDescending(s => s.Patronymic);
                    break;
                default:
                    data = data.OrderBy(s => s.Surname);
                    break;
            }

            int pageSize = 3;
            return View(PaginatedList<GuestModel>.
                Create(_mapper.Map<IEnumerable<GuestDTO>, List<GuestModel>>(data), pageNumber ?? 1, pageSize));
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
        public ActionResult Create([Bind(nameof(GuestModel.Id), nameof(GuestModel.Name),
            nameof(GuestModel.Surname), nameof(GuestModel.Patronymic),
            nameof(GuestModel.BirthDate),  nameof(GuestModel.Address),
            nameof(CategoryModel.ApplicationUser), nameof(CategoryModel.TimeStamp))] GuestModel data)
        {
            if (ModelState.IsValid)
            {
                data.ApplicationUser = new() { Id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) };
                data.TimeStamp = DateTime.Now;

                _service.Create(_mapper.Map<GuestModel, GuestDTO>(data));
                return RedirectToAction(nameof(Index));
            }
            return View(data);
        }

        // GET: GuestController/Edit/5
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
            return View(_mapper.Map<GuestDTO, GuestModel>(data));
        }

        // POST: GuestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,
            [Bind(nameof(GuestModel.Id), nameof(GuestModel.Name),
            nameof(GuestModel.Surname), nameof(GuestModel.Patronymic),
            nameof(GuestModel.BirthDate),  nameof(GuestModel.Address),
            nameof(CategoryModel.ApplicationUser), nameof(CategoryModel.TimeStamp))] GuestModel data)
        {
            if (id != data.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                data.ApplicationUser = new() { Id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) };
                data.TimeStamp = DateTime.Now;

                _service.Update(_mapper.Map<GuestModel, GuestDTO>(data));
                return RedirectToAction(nameof(Index));
            }
            return View(data);
        }

        // GET: GuestController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data =  _service.Get(id.Value);

            if (data == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<GuestDTO, GuestModel>(data));
        }

        // POST: GuestController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
