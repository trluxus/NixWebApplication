using AutoMapper;
using NixWebApplication.API.Models;
using NixWebApplication.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixWebApplication.API.Mappers
{
    public class GuestControllerMapperProfile : Profile
    {
        public GuestControllerMapperProfile()
        {
            CreateMap<GuestDTO, GuestModel>().ReverseMap();
        }
    }
}
