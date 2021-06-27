using AutoMapper;
using NixWebApplication.BLL.DTO;
using NixWebApplication.BLL.Interfaces;
using NixWebApplication.DAL.Entities;
using NixWebApplication.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixWebApplication.BLL.Services
{
    public class BookingService : IBookingService
    {
        private IWorkUnit Database { get; set; }

        public BookingService(IWorkUnit database)
        {
            this.Database = database;
        }

        public void Create(BookingDTO booking)
        {
            var mapper = new MapperConfiguration(cfg =>
                 cfg.CreateMap<BookingDTO, Booking>()).CreateMapper();

            Database.Bookings.Create(mapper.Map<BookingDTO, Booking>(booking));
        }

        public BookingDTO Get(int id)
        {
            var booking = Database.Bookings.Get(id);

            return new BookingDTO()
            {
                Id = booking.Id,
                BookingDate = booking.BookingDate,
                EnterDate = booking.EnterDate,
                LeaveDate = booking.LeaveDate,
                BookingGuest = new GuestDTO()
                {
                    Id = booking.BookingGuest.Id,
                    Name = booking.BookingGuest.Name,
                    Surname = booking.BookingGuest.Surname,
                    Patronymic = booking.BookingGuest.Patronymic,
                    BirthDate = booking.BookingGuest.BirthDate,
                    Address = booking.BookingGuest.Address
                },
                BookingRoom = new RoomDTO()
                {
                    Id = booking.BookingRoom.Id,
                    Name = booking.BookingRoom.Name,
                    IsActive = booking.BookingRoom.IsActive,
                    RoomCategory = new CategoryDTO
                    {
                        Id = booking.BookingRoom.RoomCategory.Id,
                        Name = booking.BookingRoom.RoomCategory.Name,
                        Beds = booking.BookingRoom.RoomCategory.Beds
                    }
                }
            };
        }

        public IEnumerable<BookingDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<Booking, BookingDTO>()
            ).CreateMapper();

            return mapper.Map<IEnumerable<Booking>, List<BookingDTO>>(Database.Bookings.GetAll());
        }

        public decimal Income(DateTime date)
        {
            var roomCategory = Database.Rooms.GetAll().
                Join(Database.Categories.GetAll(),
                r => r.CategoryId,
                c => c.Id,
                (r, c) => new { RoomId = r.Id, CategoryId = c.Id });

            var categoriesForIncome = Database.Bookings.GetAll().Where(i => i.EnterDate <= date && date <= i.LeaveDate).
                Join(roomCategory, b => b.RoomId, rc => rc.RoomId, (b, rc) => new { Category = rc.CategoryId }).Select(i => i.Category);


            return Database.PricesToCategories.GetAll().Where(i => i.StartDate <= date && date <= i.EndDate).
                Where(i => categoriesForIncome.Contains(i.CategoryId)).Select(i => i.Price).Sum();
        }
    }
}
