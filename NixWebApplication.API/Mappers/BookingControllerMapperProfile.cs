using AutoMapper;
using NixWebApplication.API.Models;
using NixWebApplication.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixWebApplication.API.Mappers
{
    public class BookingControllerMapperProfile : Profile
    {
        public BookingControllerMapperProfile()
        {
            CreateMap<RoomDTO, RoomModel>();
            CreateMap<GuestDTO, GuestModel>();

            CreateMap<BookingDTO, BookingModel>()
                .ForMember(i => i.BookingGuest, i => i.MapFrom(j => j.BookingGuest))
                .ForMember(i => i.BookingRoom, i => i.MapFrom(j => j.BookingRoom))
                .ReverseMap();
        }
    }
}
