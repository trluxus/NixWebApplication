using AutoMapper;
using NixWebApplication.BLL.DTO;
using NixWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixWebApplication.Mappers
{
    public class IdentityDTOMapperProfile : Profile
    {
        public IdentityDTOMapperProfile()
        {
            CreateMap<NixWebApplicationUserDTO, NixWebApplicationUserModel>()
                .ForMember(i => i.Id, i => i.MapFrom(j => j.Id))
                .ReverseMap();
        }
    }
}
