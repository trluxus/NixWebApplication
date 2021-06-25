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
    class RoomRepository : IRepository<Room>
    {
        private Context db;

        public RoomRepository(Context db)
        {
            this.db = db;
        }

        public void Create(Room room)
        {
            db.Rooms.Add(room);
        }

        public void Delete(int id)
        {
            var room = Get(id);

            if (room != null)
                db.Rooms.Remove(room);
        }

        public Room Get(int id)
        {
            return db.Rooms.Find(id);
        }

        public IEnumerable<Room> GetAll()
        {
            return db.Rooms;
        }
    }
}
