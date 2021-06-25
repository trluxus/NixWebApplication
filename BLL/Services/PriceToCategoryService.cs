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

namespace BLL.Services
{
    public class PriceToCategoryService : IService<PriceToCategoryDTO>
    {
        private IWorkUnit Database { get; set; }

        public PriceToCategoryService(IWorkUnit database)
        {
            Database = database;
        }

        public void Create(PriceToCategoryDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PriceToCategoryDTO Get(int id)
        {
            var priceToCategory = Database.PricesToCategories.Get(id);

            return new PriceToCategoryDTO()
            {
                Id = priceToCategory.Id,
                Price = priceToCategory.Price,
                StartDate = priceToCategory.StartDate,
                EndDate = priceToCategory.EndDate,
                PriceCategory = new CategoryDTO()
                {
                    Id = priceToCategory.PriceCategory.Id,
                    Name = priceToCategory.PriceCategory.Name,
                    Beds = priceToCategory.PriceCategory.Beds
                }
            };
        }

        public IEnumerable<PriceToCategoryDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<PriceToCategory, PriceToCategoryDTO>()
            ).CreateMapper();

            return mapper.Map<IEnumerable<PriceToCategory>, List<PriceToCategoryDTO>>(Database.PricesToCategories.GetAll());
        }
    }
}
