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
    public class EFWorkUnit : IWorkUnit
    {
        private Context db;
        private BookingRepository bookingRepository;
        private CategoryRepository categoryRepository;
        private GuestRepository guestRepository;
        private PriceToCategoryRepository priceToCategoryRepository;
        private RoomRepository roomRepository;

        public IRepository<Booking> Bookings
        {
            get
            {
                if (bookingRepository != null)
                    bookingRepository = new BookingRepository(db);

                return bookingRepository;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepository != null)
                    categoryRepository = new CategoryRepository(db);

                return categoryRepository;
            }
        }

        public IRepository<Guest> Guests
        {
            get
            {
                if (guestRepository != null)
                    guestRepository = new GuestRepository(db);

                return guestRepository;
            }
        }

        public IRepository<PriceToCategory> PricesToCategories
        {
            get
            {
                if (priceToCategoryRepository != null)
                    priceToCategoryRepository = new PriceToCategoryRepository(db);

                return priceToCategoryRepository;
            }
        }

        public IRepository<Room> Rooms
        {
            get
            {
                if (roomRepository != null)
                    roomRepository = new RoomRepository(db);

                return roomRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
