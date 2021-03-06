using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixWebApplication.BLL.DTO
{
    public class PriceToCategoryDTO
    {
        public int Id { get; set; }
        public CategoryDTO PriceCategory { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public NixWebApplicationUserDTO ApplicationUser { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
