using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixWebApplication.DAL.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Beds { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual NixWebApplicationUser ApplicationUser { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
