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

        public int GuestId { get; set; }
        public int RoomtId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime EnterDate { get; set; }
        public DateTime LeaveDate { get; set; }

        [ForeignKey("GuestId")]
        public virtual Guest BookingGuest { get; set; }
        [ForeignKey("RoomtId")]
        public virtual Room BookingRoom { get; set; }
    }
}
