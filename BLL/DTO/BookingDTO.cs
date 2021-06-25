﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public GuestDTO BookingGuest { get; set; }
        public RoomDTO BookingRoom { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime EnterDate { get; set; }
        public DateTime LeaveDate { get; set; }
    }
}
