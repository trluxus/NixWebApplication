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
    public class RoomService : IRoomService
    {
        private IWorkUnit Database { get; set; }
        private readonly IMapper mapper;

        public RoomService(IWorkUnit database, IMapper mapper)
        {
            this.Database = database;
            this.mapper = mapper;
        }

        public void Create(RoomDTO room)
        {
            Database.Rooms.Create(mapper.Map<RoomDTO, Room>(room));
            Database.Save();
        }

        public RoomDTO Get(int id)
        {
            var room = Database.Rooms.Get(id);

            return mapper.Map<Room, RoomDTO>(room);
        }

        public IEnumerable<RoomDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Room>, List<RoomDTO>>(Database.Rooms.GetAll());
        }

        public IEnumerable<RoomDTO> FindEmpty(DateTime enterDate, DateTime leaveDate)
        {
            var empty = Database.Rooms.GetAll().Select(i => i.Id).
                Except(Database.Bookings.GetAll().
                Where(i => i.EnterDate < leaveDate && enterDate < i.LeaveDate).
                Select(i => i.RoomId));

            var res = Database.Rooms.GetAll().Where(i => empty.Contains(i.Id) && i.IsActive);

            return mapper.Map<IEnumerable<Room>, List<RoomDTO>>(res);
        }
    }
}
