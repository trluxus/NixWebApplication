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
    class RoomServiceMapperProfile : Profile
    {
        public RoomServiceMapperProfile()
        {
            CreateMap<Category, CategoryDTO>()
                .ReverseMap(); ;
            CreateMap<Room, RoomDTO>()
                .ForMember(i => i.RoomCategory, i => i.MapFrom(j => j.RoomCategory))
                .ReverseMap();
        }
    }
}
