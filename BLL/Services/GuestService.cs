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
    public class GuestService : IService<GuestDTO>
    {
        private IWorkUnit Database { get; set; }
        
        public GuestService(IWorkUnit database)
        {
            Database = database;
        }

        public void Create(GuestDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public GuestDTO Get(int id)
        {
            var guest = Database.Guests.Get(id);

            return new GuestDTO()
            {
                Id = guest.Id,
                Name = guest.Name,
                Surname = guest.Surname,
                Patronymic = guest.Patronymic,
                BirthDate = guest.BirthDate,
                Address = guest.Address
            };
        }

        public IEnumerable<GuestDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<Guest, GuestDTO>()
            ).CreateMapper();

            return mapper.Map<IEnumerable<Guest>, List<GuestDTO>>(Database.Guests.GetAll());
        }
    }
}
