using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixWebApplication.BLL.DTO
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryDTO RoomCategory { get; set; }
        public bool IsActive { get; set; }
        public NixWebApplicationUserDTO ApplicationUser { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
