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
    class BookingMapperProfile : Profile
    {
        public BookingMapperProfile()
        {
            CreateMap<Booking, BookingDTO>()
                .ForMember(i => i.Id, i => i.MapFrom(j => j.Id))
                .ForMember(i => i.BookingGuest, i => i.MapFrom(j => j.BookingGuest))
                .ForMember(i => i.BookingRoom, i => i.MapFrom(j => j.BookingRoom))
                .ForMember(i => i.BookingDate, i => i.MapFrom(j => j.BookingDate))
                .ForMember(i => i.EnterDate, i => i.MapFrom(j => j.EnterDate))
                .ForMember(i => i.LeaveDate, i => i.MapFrom(j => j.LeaveDate))
                .ForMember(i => i.ApplicationUser, i => i.MapFrom(j => j.ApplicationUser))
                .ForMember(i => i.TimeStamp, i => i.MapFrom(j => j.TimeStamp))
                .ReverseMap();  
        }
    }
}
