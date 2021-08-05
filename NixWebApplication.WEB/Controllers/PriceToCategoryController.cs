using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NixWebApplication.BLL.DTO;
using NixWebApplication.BLL.Interfaces;
using NixWebApplication.Models;
using NixWebApplication.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixWebApplication.WEB.Controllers
{
    [Authorize]
    public class PriceToCategoryController : Controller
    {
        private readonly IPriceToCategoryService _priceToCategoryService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public PriceToCategoryController(IPriceToCategoryService priceToCategoryService, ICategoryService categoryService, IMapper mapper)
        {
            this._priceToCategoryService = priceToCategoryService;
            this._categoryService = categoryService;
            this._mapper = mapper;
        }

        // GET: PriceToCategoryController
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

            ViewData["CategoryNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "categoryName_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["StartDateSortParm"] = sortOrder == "StartDate" ? "startDate_desc" : "StartDate";
            ViewData["EndDateParm"] = sortOrder == "EndDate" ? "endDate_desc" : "EndDate";

            ViewData["CurrentFilter"] = searchString;

            var data = _priceToCategoryService.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                data = data.Where(s => s.PriceCategory.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "categoryName_desc":
                    data = data.OrderByDescending(s => s.PriceCategory.Name);
                    break;
                case "Price":
                    data = data.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    data = data.OrderByDescending(s => s.Price);
                    break;
                case "StartDate":
                    data = data.OrderBy(s => s.StartDate);
                    break;
                case "startDate_desc":
                    data = data.OrderByDescending(s => s.StartDate);
                    break;
                case "EndDate":
                    data = data.OrderBy(s => s.EndDate);
                    break;
                case "endDate_desc":
                    data = data.OrderByDescending(s => s.EndDate);
                    break;
                default:
                    data = data.OrderBy(s => s.PriceCategory.Name);
                    break;
            }

            int pageSize = 3;

            return View(PaginatedList<PriceToCategoryModel>.
                Create(_mapper.Map<IEnumerable<PriceToCategoryDTO>, List<PriceToCategoryModel>>(data), pageNumber ?? 1, pageSize));
        }

        // GET: PriceToCategoryController/Details/5
        public ActionResult Details(int id)
        {
            var data = _priceToCategoryService.Get(id);         

            return View(_mapper.Map<PriceToCategoryDTO, PriceToCategoryModel>(data));
        }

        // GET: PriceToCategoryController/Create
        public ActionResult Create()
        {
            ViewBag.CategoriesForPrices = new SelectList(_categoryService.GetAll(),
                nameof(CategoryModel.Id), nameof(CategoryModel.Name), null);

            return View();
        }

        // POST: PriceToCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,PriceCategory,Price,StartDate,EndDate")] PriceToCategoryModel data)
        {
            if (ModelState.IsValid)
            {
                _priceToCategoryService.Create(_mapper.Map<PriceToCategoryModel, PriceToCategoryDTO>(data));

                return RedirectToAction(nameof(Index));
            }

            ViewBag.CategoriesForPrices = new SelectList(_categoryService.GetAll(),
                nameof(CategoryModel.Id), nameof(CategoryModel.Name), data.PriceCategory.Id);

            return View(data);
        }

        // GET: PriceToCategoryController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = _priceToCategoryService.Get(id.Value);

            if (data == null)
            {
                return NotFound();
            }

            ViewBag.CategoriesForPrices = new SelectList(_categoryService.GetAll(),
                nameof(CategoryModel.Id), nameof(CategoryModel.Name), data.PriceCategory.Id);

            return View(_mapper.Map<PriceToCategoryDTO, PriceToCategoryModel>(data));
        }

        // POST: PriceToCategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,PriceCategory,Price,StartDate,EndDate")] PriceToCategoryModel data)
        {
            if (id != data.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _priceToCategoryService.Update(_mapper.Map<PriceToCategoryModel, PriceToCategoryDTO>(data));

                return RedirectToAction(nameof(Index));
            }

            ViewBag.CategoriesForPrices = new SelectList(_categoryService.GetAll(),
                nameof(CategoryModel.Id), nameof(CategoryModel.Name), data.PriceCategory.Id);

            return View(data);
        }

        // GET: PriceToCategoryController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = _priceToCategoryService.Get(id.Value);

            if (data == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PriceToCategoryDTO, PriceToCategoryModel>(data));
        }

        // POST: PriceToCategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _priceToCategoryService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
