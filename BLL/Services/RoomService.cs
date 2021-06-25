using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RoomService : IService<RoomDTO>
    {
        private IWorkUnit Database { get; set; }

        public RoomService(IWorkUnit database)
        {
            Database = database;
        }

        public void Create(RoomDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
    }
}
