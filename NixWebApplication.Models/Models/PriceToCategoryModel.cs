using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NixWebApplication.Models
{
    public class PriceToCategoryModel
    {
        public int Id { get; set; }
        public CategoryModel PriceCategory { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public NixWebApplicationUserModel ApplicationUser { get; set; }
        public DateTime TimeStamp { get; set; }

        public override bool Equals(object obj)
        {
            return obj is PriceToCategoryModel model &&
                   Id == model.Id &&
                   EqualityComparer<CategoryModel>.Default.Equals(PriceCategory, model.PriceCategory) &&
                   Price == model.Price &&
                   StartDate == model.StartDate &&
                   EndDate == model.EndDate;
        }
    }
}
