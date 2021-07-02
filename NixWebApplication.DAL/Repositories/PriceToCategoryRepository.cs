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
    class PriceToCategoryRepository : IRepository<PriceToCategory>
    {
        private NixAppContext _db;

        public PriceToCategoryRepository(NixAppContext db)
        {
            this._db = db;
        }

        public void Create(PriceToCategory priceToCategory)
        {
            _db.PricesToCategories.Add(priceToCategory);
        }

        public void Delete(int id)
        {
            var priceToCategory = Get(id);

            if (priceToCategory != null)
                _db.PricesToCategories.Remove(priceToCategory);
        }

        public PriceToCategory Get(int id)
        {
            return _db.PricesToCategories.Find(id);
        }

        public IEnumerable<PriceToCategory> GetAll()
        {
            return _db.PricesToCategories;
        }
    }
}
