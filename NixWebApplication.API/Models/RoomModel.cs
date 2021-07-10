using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixWebApplication.API.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryModel RoomCategory { get; set; }
        public bool IsActive { get; set; }

        public override bool Equals(object obj)
        {
            return obj is RoomModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   EqualityComparer<CategoryModel>.Default.Equals(RoomCategory, model.RoomCategory) &&
                   IsActive == model.IsActive;
        }
    }
}
