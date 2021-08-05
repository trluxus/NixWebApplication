using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixWebApplication.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Beds { get; set; }
        public NixWebApplicationUserModel ApplicationUser { get; set; }
        public DateTime TimeStamp { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CategoryModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   Beds == model.Beds;
        }
    }
}
