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
            CreateMap<Guest, GuestDTO>()
                .ReverseMap(); 
            CreateMap<Room, RoomDTO>()
                .ReverseMap();
            CreateMap<Booking, BookingDTO>()
                .ForMember(i => i.BookingGuest, i => i.MapFrom(j => j.BookingGuest))
                .ForMember(i => i.BookingRoom, i => i.MapFrom(j => j.BookingRoom))
                .ReverseMap();  
        }
    }
}
