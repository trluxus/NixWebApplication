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
        private readonly NixAppContext db;

        public BookingRepository(NixAppContext db)
        {
            this.db = db;
        }

        public void Create(Booking booking)
        {
            db.Attach(booking.BookingGuest);
            db.Attach(booking.BookingRoom);
            db.Bookings.Add(booking);
        }

        public void Delete(int id)
        {
            var booking = Get(id);

            if (booking != null)
                db.Bookings.Remove(booking);
        }

        public Booking Get(int id)
        {
            return db.Bookings
                .Include(b => b.BookingGuest)
                .Include(b => b.BookingRoom)
                .FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Booking> GetAll()
        {
            return db.Bookings
                .Include(b => b.BookingGuest)
                .Include(b => b.BookingRoom);
        }
    }
}
