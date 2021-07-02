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
    class GuestRepository : IRepository<Guest>
    {
        private NixAppContext _db;

        public GuestRepository(NixAppContext db)
        {
            this._db = db;
        }

        public void Create(Guest guest)
        {
            _db.Guests.Add(guest);
        }

        public void Delete(int id)
        {
            var guest = Get(id);

            if (guest != null)
                _db.Guests.Remove(guest);
        }

        public Guest Get(int id)
        {
            return _db.Guests.Find(id);
        }

        public IEnumerable<Guest> GetAll()
        {
            return _db.Guests;
        }
    }
}
