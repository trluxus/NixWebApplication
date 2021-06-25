using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class BookingRepository : IRepository<Booking>
    {
        private Context db;

        public BookingRepository(Context db)
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
