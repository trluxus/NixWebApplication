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
        private readonly IMapper mapper;

        public BookingService(IWorkUnit database, IMapper mapper)
        {
            this.Database = database;
            this.mapper = mapper;
        }

        public void Create(BookingDTO booking)
        {
            Database.Bookings.Create(mapper.Map<BookingDTO, Booking>(booking));
            Database.Save();
        }

        public BookingDTO Get(int id)
        {
            var booking = Database.Bookings.Get(id);

            return mapper.Map<Booking, BookingDTO>(booking); 
        }

        public IEnumerable<BookingDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Booking>, List<BookingDTO>>(Database.Bookings.GetAll());
        }

        public decimal Income(DateTime date)
        {
            var roomCategory = Database.Rooms.GetAll().
                Join(Database.Categories.GetAll(),
                r => r.CategoryId,
                c => c.Id,
                (r, c) => new { RoomId = r.Id, CategoryId = c.Id });

            var categoriesForIncome = Database.Bookings.GetAll()
                .Where(i => i.EnterDate.Month <= date.Month 
                    && date.Month <= i.LeaveDate.Month)
                .Join(roomCategory, 
                    b => b.RoomId, 
                    rc => rc.RoomId, 
                    (b, rc) => new { Category = rc.CategoryId })
                .Select(i => i.Category);

            return Database.PricesToCategories.GetAll().Where(i => i.StartDate <= date && date <= i.EndDate).
                Where(i => categoriesForIncome.Contains(i.CategoryId)).Select(i => i.Price).Sum();
        }
    }
}
