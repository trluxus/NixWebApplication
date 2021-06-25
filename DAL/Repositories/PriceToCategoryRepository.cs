﻿using NixWebApplication.DAL.EF;
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
        private Context db;

        public PriceToCategoryRepository(Context db)
        {
            this.db = db;
        }

        public void Create(PriceToCategory priceToCategory)
        {
            db.PricesToCategories.Add(priceToCategory);
        }

        public void Delete(int id)
        {
            var priceToCategory = Get(id);

            if (priceToCategory != null)
                db.PricesToCategories.Remove(priceToCategory);
        }

        public PriceToCategory Get(int id)
        {
            return db.PricesToCategories.Find(id);
        }

        public IEnumerable<PriceToCategory> GetAll()
        {
            return db.PricesToCategories;
        }
    }
}