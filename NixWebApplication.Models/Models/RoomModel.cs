using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixWebApplication.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryModel RoomCategory { get; set; }
        public bool IsActive { get; set; }
        public NixWebApplicationUserModel ApplicationUser { get; set; }
        public DateTime TimeStamp { get; set; }

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
