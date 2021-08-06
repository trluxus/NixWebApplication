using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NixWebApplication.BLL.DTO;
using NixWebApplication.BLL.Interfaces;
using NixWebApplication.Models;
using NixWebApplication.Pagination;
using NixWebApplication.WEB.Models.BookingViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NixWebApplication.WEB.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IGuestService _guestService;
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public BookingController(IBookingService bookingService,
            IGuestService guestService, IRoomService roomService, IMapper mapper, 
            IHttpContextAccessor httpContextAccessor)
        {
            this._bookingService = bookingService;
            this._guestService = guestService;
            this._roomService = roomService;
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
        }

        // GET: BookingController
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

            ViewData["GuestSurnameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "guestSurname_desc" : "";
            ViewData["RoomNameSortParm"] = sortOrder == "RoomName" ? "roomName_desc" : "RoomName";
            ViewData["BookingDateParm"] = sortOrder == "BookingDate" ? "bookingDate_desc" : "BookingDate";
            ViewData["EnterDateParm"] = sortOrder == "EnterDate" ? "enterDate_desc" : "EnterDate";
            ViewData["LeaveDateParm"] = sortOrder == "LeaveDate" ? "leaveDate_desc" : "LeaveDate";

            ViewData["CurrentFilter"] = searchString;

            var data = _bookingService.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                data = data.Where(s => s.BookingGuest.Surname.Contains(searchString, StringComparison.InvariantCultureIgnoreCase)
                                     || s.BookingRoom.Name.Contains(searchString, StringComparison.InvariantCultureIgnoreCase));
            }

            switch (sortOrder)
            {
                case "guestSurname_desc":
                    data = data.OrderByDescending(s => s.BookingGuest.Surname);
                    break;
                case "RoomName":
                    data = data.OrderBy(s => s.BookingRoom.Name);
                    break;
                case "roomName_desc":
                    data = data.OrderByDescending(s => s.BookingRoom.Name);
                    break;
                case "BookingDate":
                    data = data.OrderBy(s => s.BookingDate);
                    break;
                case "bookingDate_desc":
                    data = data.OrderByDescending(s => s.BookingDate);
                    break;
                case "EnterDate":
                    data = data.OrderBy(s => s.EnterDate);
                    break;
                case "enterDate_desc":
                    data = data.OrderByDescending(s => s.EnterDate);
                    break;
                case "LeaveDate":
                    data = data.OrderBy(s => s.LeaveDate);
                    break;
                case "leaveDate_desc":
                    data = data.OrderByDescending(s => s.LeaveDate);
                    break;
                default:
                    data = data.OrderBy(s => s.BookingGuest.Surname);
                    break;
            }

            int pageSize = 3;

            return View(PaginatedList<BookingModel>.
                Create(_mapper.Map<IEnumerable<BookingDTO>, List<BookingModel>>(data), pageNumber ?? 1, pageSize));
        }

        // GET: BookingController/Details/5
        public ActionResult Details(int id)
        {
            var data = _bookingService.Get(id);

            return View(_mapper.Map<BookingDTO, BookingModel>(data));
        }

        // GET: BookingController/Create
        public ActionResult Create()
        {
            ViewBag.GuestsForBookings = new SelectList(_guestService.GetAll(),
                nameof(GuestModel.Id), nameof(GuestModel.Name), null);

            ViewBag.RoomsForBookings = new SelectList(_roomService.GetAll(),
                nameof(RoomModel.Id), nameof(RoomModel.Name), null);

            return View();
        }

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(nameof(BookingModel.Id), nameof(BookingModel.BookingGuest),
            nameof(BookingModel.BookingRoom), nameof(BookingModel.BookingDate),
            nameof(BookingModel.EnterDate), nameof(BookingModel.LeaveDate),
            nameof(CategoryModel.ApplicationUser), nameof(CategoryModel.TimeStamp))] BookingModel data)
        {
            if (ModelState.IsValid)
            {
                data.ApplicationUser = new() { Id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) };
                data.TimeStamp = DateTime.Now;

                data.BookingDate = DateTime.Now;

                _bookingService.Create(_mapper.Map<BookingModel, BookingDTO>(data));

                return RedirectToAction(nameof(Index));
            }

            ViewBag.GuestsForBookings = new SelectList(_guestService.GetAll(),
                nameof(GuestModel.Id), nameof(GuestModel.Name), data.BookingGuest.Id);

            ViewBag.RoomsForBookings = new SelectList(_roomService.GetAll(),
                nameof(RoomModel.Id), nameof(RoomModel.Name), data.BookingRoom.Id);

            return View(data);
        }

        // GET: BookingController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = _bookingService.Get(id.Value);

            if (data == null)
            {
                return NotFound();
            }

            ViewBag.GuestsForBookings = new SelectList(_guestService.GetAll(),
               nameof(GuestModel.Id), nameof(GuestModel.Name), data.BookingGuest.Id);

            ViewBag.RoomsForBookings = new SelectList(_roomService.GetAll(),
                nameof(RoomModel.Id), nameof(RoomModel.Name), data.BookingRoom.Id);

            return View(_mapper.Map<BookingDTO, BookingModel>(data));
        }

        // POST: BookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,
            [Bind(nameof(BookingModel.Id), nameof(BookingModel.BookingGuest),
            nameof(BookingModel.BookingRoom), nameof(BookingModel.BookingDate),
            nameof(BookingModel.EnterDate), nameof(BookingModel.LeaveDate),
            nameof(CategoryModel.ApplicationUser), nameof(CategoryModel.TimeStamp))] BookingModel data)
        {
            if (id != data.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                data.ApplicationUser = new() { Id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) };
                data.TimeStamp = DateTime.Now;

                _bookingService.Update(_mapper.Map<BookingModel, BookingDTO>(data));

                return RedirectToAction(nameof(Index));
            }

            ViewBag.GuestsForBookings = new SelectList(_guestService.GetAll(),
              nameof(GuestModel.Id), nameof(GuestModel.Name), data.BookingGuest.Id);

            ViewBag.RoomsForBookings = new SelectList(_roomService.GetAll(),
                nameof(RoomModel.Id), nameof(RoomModel.Name), data.BookingRoom.Id);

            return View(data);
        }

        // GET: BookingController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = _bookingService.Get(id.Value);

            if (data == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<BookingDTO, BookingModel>(data));
        }

        // POST: BookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _bookingService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        // GET: BookingController/income/2020-01-20
        public ActionResult Income()
        {
            return View();         
        }

        // POST: BookingController/Income/2020-01-20
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IncomeResult(IncomeViewModel data)
        {
            return View(_bookingService.Income(data.Date));
        }
    }
}
