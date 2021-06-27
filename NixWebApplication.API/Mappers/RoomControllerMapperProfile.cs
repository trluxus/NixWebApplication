using AutoMapper;
using NixWebApplication.API.Models;
using NixWebApplication.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixWebApplication.API.Mappers
{
    public class RoomControllerMapperProfile : Profile
    {
        public RoomControllerMapperProfile()
        {
            CreateMap<RoomDTO, RoomModel>();
            CreateMap<CategoryDTO, CategoryModel>();
            CreateMap<RoomModel, RoomDTO>();
            CreateMap<CategoryModel, CategoryDTO>();
        }
    }
}
