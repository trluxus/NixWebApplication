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

        public RoomService(IWorkUnit database)
        {
            this.Database = database;
        }

        public void Create(RoomDTO room)
        {
            var mapper = new MapperConfiguration(cfg =>
                 cfg.CreateMap<RoomDTO, Room>()).CreateMapper();

            Database.Rooms.Create(mapper.Map<RoomDTO, Room>(room));
        }

        public RoomDTO Get(int id)
        {
            var room = Database.Rooms.Get(id);

            return new RoomDTO()
            {
                Id = room.Id,
                Name = room.Name,
                IsActive = room.IsActive,
                RoomCategory = new CategoryDTO()
                {
                    Id = room.RoomCategory.Id,
                    Name = room.RoomCategory.Name,
                    Beds = room.RoomCategory.Beds
                }
            };
        }

        public IEnumerable<RoomDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<Room, RoomDTO>()
            ).CreateMapper();

            return mapper.Map<IEnumerable<Room>, List<RoomDTO>>(Database.Rooms.GetAll());
        }

        public IEnumerable<RoomDTO> FindEmpty(DateTime enterDate, DateTime leaveDate)
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<Room, RoomDTO>()
            ).CreateMapper();

            var empty = Database.Rooms.GetAll().Select(i => i.Id).
                Except(Database.Bookings.GetAll().
                Where(i => i.EnterDate < leaveDate && enterDate < i.LeaveDate).
                Select(i => i.RoomId));

            return mapper.Map<IEnumerable<Room>, List<RoomDTO>>(Database.Rooms.GetAll().
                Where(i => empty.Contains(i.Id)));
        }
    }
}
