using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixWebApplication.DAL.Entities
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int GuestId { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime BookingDate { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime EnterDate { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime LeaveDate { get; set; }

        [ForeignKey("GuestId")]
        public virtual Guest BookingGuest { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room BookingRoom { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual NixWebApplicationUser ApplicationUser { get; set; }
    }
}
