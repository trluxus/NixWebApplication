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
    public class EFWorkUnit : IWorkUnit
    {
        private readonly NixAppContext _db;
        private BookingRepository _bookingRepository;
        private CategoryRepository _categoryRepository;
        private GuestRepository _guestRepository;
        private PriceToCategoryRepository _priceToCategoryRepository;
        private RoomRepository _roomRepository;

        public EFWorkUnit(NixAppContext dbContext)
        {
            _db = dbContext;
        }

        public IRepository<Booking> Bookings
        {
            get
            {
                if (_bookingRepository == null)
                    _bookingRepository = new BookingRepository(_db);

                return _bookingRepository;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository(_db);

                return _categoryRepository;
            }
        }

        public IRepository<Guest> Guests
        {
            get
            {
                if (_guestRepository == null)
                    _guestRepository = new GuestRepository(_db);

                return _guestRepository;
            }
        }

        public IRepository<PriceToCategory> PricesToCategories
        {
            get
            {
                if (_priceToCategoryRepository == null)
                    _priceToCategoryRepository = new PriceToCategoryRepository(_db);

                return _priceToCategoryRepository;
            }
        }

        public IRepository<Room> Rooms
        {
            get
            {
                if (_roomRepository == null)
                    _roomRepository = new RoomRepository(_db);

                return _roomRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
