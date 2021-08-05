using NixWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixWebApplication.WEB.Models.RoomViewModels
{
    public class RoomViewModel
    {
        public RoomModel Room { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}
