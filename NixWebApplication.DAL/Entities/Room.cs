using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NixWebApplication.DAL.Entities
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category RoomCategory { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual NixWebApplicationUser ApplicationUser { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
