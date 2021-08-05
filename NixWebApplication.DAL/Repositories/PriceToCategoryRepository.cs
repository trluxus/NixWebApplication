using Microsoft.EntityFrameworkCore;
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
        private readonly NixAppContext _db;

        public PriceToCategoryRepository(NixAppContext db)
        {
            this._db = db;
        }

        public void Create(PriceToCategory item)
        {
            _db.Attach(item.ApplicationUser);
            _db.Attach(item.PriceCategory);
            _db.PricesToCategories.Add(item);
        }

        public void Delete(int id)
        {
            var priceToCategory = Get(id);

            if (priceToCategory != null)
                _db.PricesToCategories.Remove(priceToCategory);
        }

        public PriceToCategory Get(int id)
        {
            return _db.PricesToCategories
                .Include(b => b.ApplicationUser)
                .Include(i => i.PriceCategory)
                .FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<PriceToCategory> GetAll()
        {
            return _db.PricesToCategories
                .Include(b => b.ApplicationUser)
                .Include(i => i.PriceCategory);
        }

        public void Update(PriceToCategory item)
        {
            _db.Attach(item.ApplicationUser);
            _db.Attach(item.PriceCategory);
            _db.PricesToCategories.Update(item);
        }
    }
}
