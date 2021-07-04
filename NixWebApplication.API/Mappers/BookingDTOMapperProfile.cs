using AutoMapper;
using NixWebApplication.API.Models;
using NixWebApplication.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixWebApplication.API.Mappers
{
    public class BookingDTOMapperProfile : Profile
    {
        public BookingDTOMapperProfile()
        {
            CreateMap<RoomDTO, RoomModel>()
                .ReverseMap();
            CreateMap<BookingDTO, BookingModel>()
                .ForMember(i => i.Id, i => i.MapFrom(j => j.Id))
                .ForMember(i => i.BookingGuest, i => i.MapFrom(j => j.BookingGuest))
                .ForMember(i => i.BookingRoom, i => i.MapFrom(j => j.BookingRoom))
                .ForMember(i => i.BookingDate, i => i.MapFrom(j => j.BookingDate))
                .ForMember(i => i.EnterDate, i => i.MapFrom(j => j.EnterDate))
                .ForMember(i => i.LeaveDate, i => i.MapFrom(j => j.LeaveDate))
                .ReverseMap();
        }
    }
}
