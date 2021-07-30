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
        private readonly IWorkUnit _database;
        private readonly IMapper _mapper;

        public GuestService(IWorkUnit database, IMapper mapper)
        {
            this._database = database;
            this._mapper = mapper;
        }

        public void Create(GuestDTO guest)
        {
            _database.Guests.Create(_mapper.Map<GuestDTO, Guest>(guest));
            _database.Save();
        }

        public void Delete(int id)
        {
            _database.Guests.Delete(id);
            _database.Save();
        }

        public GuestDTO Get(int id)
        {
            var guest = _database.Guests.Get(id);

            return _mapper.Map<Guest, GuestDTO>(guest);    
        }

        public IEnumerable<GuestDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Guest>, List<GuestDTO>>(_database.Guests.GetAll());
        }

        public void Update(GuestDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
