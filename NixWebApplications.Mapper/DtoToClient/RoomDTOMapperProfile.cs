using AutoMapper;
using NixWebApplication.BLL.DTO;
using NixWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixWebApplication.Mappers
{
    public class RoomDTOMapperProfile : Profile
    {
        public RoomDTOMapperProfile()
        {
            CreateMap<RoomDTO, RoomModel>()
                .ForMember(i => i.Id, i => i.MapFrom(j => j.Id))
                .ForMember(i => i.Name, i => i.MapFrom(j => j.Name))
                .ForMember(i => i.RoomCategory, i => i.MapFrom(j => j.RoomCategory))
                .ForMember(i => i.IsActive, i => i.MapFrom(j => j.IsActive))
                .ReverseMap();
        }
    }
}
