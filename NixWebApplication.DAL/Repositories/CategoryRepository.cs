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
        private NixAppContext _db;

        public CategoryRepository(NixAppContext db)
        {
            this._db = db;
        }

        public void Create(Category category)
        {
            _db.Categories.Add(category);
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
    }
}
