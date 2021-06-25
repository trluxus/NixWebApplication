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
    public class CategoryService : IService<CategoryDTO>
    {
        private IWorkUnit Database { get; set; }

        public CategoryService(IWorkUnit database)
        {
            Database = database;
        }

        public void Create(CategoryDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryDTO Get(int id)
        {
            var category = Database.Categories.Get(id);

            return new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name,
                Beds = category.Beds
            };
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<Category, CategoryDTO>()
            ).CreateMapper();

            return mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(Database.Categories.GetAll());
        }
    }
}
