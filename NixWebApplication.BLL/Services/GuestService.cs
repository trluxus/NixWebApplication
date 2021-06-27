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
    public class GuestService : IGuestService
    {
        private IWorkUnit Database { get; set; }
        private readonly IMapper mapper;

        public GuestService(IWorkUnit database, IMapper mapper)
        {
            this.Database = database;
            this.mapper = mapper;
        }

        public void Create(GuestDTO guest)
        {
            Database.Guests.Create(mapper.Map<GuestDTO, Guest>(guest));
            Database.Save();
        }

        public GuestDTO Get(int id)
        {
            var guest = Database.Guests.Get(id);

            return mapper.Map<Guest, GuestDTO>(guest);    
        }

        public IEnumerable<GuestDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Guest>, List<GuestDTO>>(Database.Guests.GetAll());
        }
    }
}
