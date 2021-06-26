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
    }
}
