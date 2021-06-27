using AutoMapper;
using NixWebApplication.BLL.DTO;
using NixWebApplication.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixWebApplication.BLL.Mappers
{
    class BookingServiceMapperProfile : Profile
    {
        public BookingServiceMapperProfile()
        {
            CreateMap<Booking, BookingDTO>();
            CreateMap<Room, RoomDTO>();
            CreateMap<Guest, GuestDTO>();
            CreateMap<BookingDTO, Booking>();
        }
    }
}
