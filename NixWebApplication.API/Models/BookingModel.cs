using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixWebApplication.API.Models
{
    public class BookingModel
    {
        public int Id { get; set; }
        public GuestModel BookingGuest { get; set; }
        public RoomModel BookingRoom { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime EnterDate { get; set; }
        public DateTime LeaveDate { get; set; }
    }
}
