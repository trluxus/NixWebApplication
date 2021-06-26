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
        private NixAppContext db;

        public BookingRepository(NixAppContext db)
        {
            this.db = db;
        }

        public void Create(Booking booking)
        {
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
            return db.Bookings.Find(id);
        }

        public IEnumerable<Booking> GetAll()
        {
            return db.Bookings;
        }
    }
}
