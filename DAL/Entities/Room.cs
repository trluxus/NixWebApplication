using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Entities
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int CategoryId { get; set; }
        public bool IsAtive { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category RoomCategory { get; set; }
    }
}
