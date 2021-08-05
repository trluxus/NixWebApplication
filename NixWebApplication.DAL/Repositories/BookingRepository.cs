using Microsoft.EntityFrameworkCore;
using NixWebApplication.DAL.EF;
using NixWebApplication.DAL.Entities;
using NixWebApplication.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixWebApplication.DAL.Repositories
{
    class BookingRepository : IRepository<Booking>
    {
        private readonly NixAppContext _db;

        public BookingRepository(NixAppContext db)
        {
            this._db = db;
        }

        public void Create(Booking item)
        {
            _db.Attach(item.ApplicationUser);
            _db.Attach(item.BookingGuest);
            _db.Attach(item.BookingRoom);
            _db.Bookings.Add(item);
        }

        public void Delete(int id)
        {
            var booking = Get(id);

            if (booking != null)
                _db.Bookings.Remove(booking);
        }

        public Booking Get(int id)
        {
            return _db.Bookings
                .Include(b => b.ApplicationUser)
                .Include(b => b.BookingGuest)
                .Include(b => b.BookingRoom)
                .FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Booking> GetAll()
        {
            return _db.Bookings
                .Include(b => b.ApplicationUser)
                .Include(b => b.BookingGuest)
                .Include(b => b.BookingRoom);
        }

        public void Update(Booking item)
        {
            _db.Attach(item.ApplicationUser);
            _db.Attach(item.BookingGuest);
            _db.Attach(item.BookingRoom);
            _db.Bookings.Update(item);
        }
    }
}
