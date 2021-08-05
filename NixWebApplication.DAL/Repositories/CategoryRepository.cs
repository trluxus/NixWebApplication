using NixWebApplication.DAL.EF;
using NixWebApplication.DAL.Entities;
using NixWebApplication.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixWebApplication.DAL.Repositories
{
    class CategoryRepository : IRepository<Category>
    {
        private readonly NixAppContext _db;

        public CategoryRepository(NixAppContext db)
        {
            this._db = db;
        }

        public void Create(Category item)
        {
            _db.Categories.Add(item);
        }

        public void Delete(int id)
        {
            var category = Get(id);

            if (category != null)
                _db.Categories.Remove(category);
        }

        public Category Get(int id)
        {
            return _db.Categories.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.Categories;
        }

        public void Update(Category item)
        {
            _db.Categories.Update(item);
        }
    }
}
