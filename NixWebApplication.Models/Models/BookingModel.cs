using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixWebApplication.Models
{
    public class BookingModel
    {
        public int Id { get; set; }
        public GuestModel BookingGuest { get; set; }
        public RoomModel BookingRoom { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime EnterDate { get; set; }
        public DateTime LeaveDate { get; set; }

        public override bool Equals(object obj)
        {
            return obj is BookingModel model &&
                   Id == model.Id &&
                   EqualityComparer<GuestModel>.Default.Equals(BookingGuest, model.BookingGuest) &&
                   EqualityComparer<RoomModel>.Default.Equals(BookingRoom, model.BookingRoom) &&
                   BookingDate == model.BookingDate &&
                   EnterDate == model.EnterDate &&
                   LeaveDate == model.LeaveDate;
        }
    }
}
