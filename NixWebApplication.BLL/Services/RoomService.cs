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
        private readonly IWorkUnit _database;
        private readonly IMapper _mapper;

        public RoomService(IWorkUnit database, IMapper mapper)
        {
            this._database = database;
            this._mapper = mapper;
        }

        public void Create(RoomDTO item)
        {
            _database.Rooms.Create(_mapper.Map<RoomDTO, Room>(item));
            _database.Save();
        }

        public void Delete(int id)
        {
            _database.Rooms.Delete(id);
            _database.Save();
        }

        public IEnumerable<RoomDTO> FindEmpty(DateTime enterDate, DateTime leaveDate)
        {
            var empty = _database.Rooms.GetAll().Select(i => i.Id).
                Except(_database.Bookings.GetAll().
                Where(i => i.EnterDate < leaveDate && enterDate < i.LeaveDate).
                Select(i => i.RoomId));

            var res = _database.Rooms.GetAll().Where(i => empty.Contains(i.Id) && i.IsActive);

            return _mapper.Map<IEnumerable<Room>, List<RoomDTO>>(res);
        }

        public RoomDTO Get(int id)
        {
            var room = _database.Rooms.Get(id);

            return _mapper.Map<Room, RoomDTO>(room);
        }

        public IEnumerable<RoomDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Room>, List<RoomDTO>>(_database.Rooms.GetAll());
        }

        public void Update(RoomDTO item)
        {
            _database.Rooms.Update(_mapper.Map<RoomDTO, Room>(item));
            _database.Save();
        }
    }
}
