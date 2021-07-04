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
    class RoomRepository : IRepository<Room>
    {
        private readonly NixAppContext _db;

        public RoomRepository(NixAppContext db)
        {
            this._db = db;
        }

        public void Create(Room room)
        {
            _db.Attach(room.RoomCategory);
            _db.Rooms.Add(room);
        }

        public void Delete(int id)
        {
            var room = Get(id);

            if (room != null)
                _db.Rooms.Remove(room);
        }

        public Room Get(int id)
        {
            return _db.Rooms
                .Include(i => i.RoomCategory)
                .FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Room> GetAll()
        {
            return _db.Rooms
                .Include(i => i.RoomCategory);
        }
    }
}
