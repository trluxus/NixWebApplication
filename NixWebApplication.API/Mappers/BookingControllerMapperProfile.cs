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
            CreateMap<BookingDTO, BookingModel>();
            CreateMap<RoomDTO, RoomModel>();
            CreateMap<GuestDTO, GuestModel>();
            CreateMap<CategoryModel, CategoryDTO>();
        }
    }
}
