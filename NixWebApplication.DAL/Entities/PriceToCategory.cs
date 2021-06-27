using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixWebApplication.DAL.Entities
{
    public class PriceToCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category PriceCategory { get; set; }
    }
}
