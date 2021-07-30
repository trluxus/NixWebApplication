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
        private readonly IWorkUnit _database;
        private readonly IMapper _mapper;

        public BookingService(IWorkUnit database, IMapper mapper)
        {
            this._database = database;
            this._mapper = mapper;
        }

        public void Create(BookingDTO booking)
        {           
            _database.Bookings.Create(_mapper.Map<BookingDTO, Booking>(booking));
            _database.Save();
        }

        public void Delete(int id)
        {
            _database.Bookings.Delete(id);
            _database.Save();
        }

        public BookingDTO Get(int id)
        {
            var booking = _database.Bookings.Get(id);

            return _mapper.Map<Booking, BookingDTO>(booking); 
        }

        public IEnumerable<BookingDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Booking>, List<BookingDTO>>(_database.Bookings.GetAll());
        }

        public decimal Income(DateTime date)
        {
            var roomCategory = _database.Rooms.GetAll().
                Join(_database.Categories.GetAll(),
                r => r.CategoryId,
                c => c.Id,
                (r, c) => new { RoomId = r.Id, CategoryId = c.Id });

            var categoriesForIncome = _database.Bookings.GetAll()
                .Where(i => i.EnterDate.Month <= date.Month 
                    && date.Month <= i.LeaveDate.Month)
                .Join(roomCategory, 
                    b => b.RoomId, 
                    rc => rc.RoomId, 
                    (b, rc) => new { Category = rc.CategoryId })
                .Select(i => i.Category);

            return _database.PricesToCategories.GetAll().Where(i => i.StartDate <= date && date <= i.EndDate).
                Where(i => categoriesForIncome.Contains(i.CategoryId)).Select(i => i.Price).Sum();
        }

        public void Update(BookingDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
