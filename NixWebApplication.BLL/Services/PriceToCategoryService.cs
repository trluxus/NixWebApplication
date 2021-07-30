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
    public class PriceToCategoryService : IPriceToCategoryService
    {
        private readonly IWorkUnit _database;
        private readonly IMapper _mapper;

        public PriceToCategoryService(IWorkUnit database, IMapper mapper)
        {
            this._database = database;
            this._mapper = mapper;
        }

        public void Create(PriceToCategoryDTO item)
        {
            _database.PricesToCategories.Create(_mapper.Map<PriceToCategoryDTO, PriceToCategory>(item));
            _database.Save();
        }

        public void Delete(int id)
        {
            _database.PricesToCategories.Delete(id);
            _database.Save();
        }

        public PriceToCategoryDTO Get(int id)
        {
            var priceToCategory = _database.PricesToCategories.Get(id);

            return _mapper.Map<PriceToCategory, PriceToCategoryDTO>(priceToCategory);
        }

        public IEnumerable<PriceToCategoryDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<PriceToCategory>, List<PriceToCategoryDTO>>(_database.PricesToCategories.GetAll());
        }

        public void Update(PriceToCategoryDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
