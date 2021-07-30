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
    public class CategoryService : ICategoryService
    {
        private readonly IWorkUnit _database;
        private readonly IMapper _mapper;

        public CategoryService(IWorkUnit database, IMapper mapper)
        {
            this._database = database;
            this._mapper = mapper;
        }

        public void Create(CategoryDTO item)
        {
            _database.Categories.Create(_mapper.Map<CategoryDTO, Category>(category));
            _database.Save();
        }

        public void Delete(int id)
        {
            _database.Guests.Delete(id);
            _database.Save();
        }

        public CategoryDTO Get(int id)
        {
            var category = _database.Categories.Get(id);

            return _mapper.Map<Category, CategoryDTO>(category);
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(_database.Categories.GetAll());
        }

        public void Update(CategoryDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
