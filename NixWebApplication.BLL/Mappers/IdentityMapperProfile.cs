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
    public class IdentityMapperProfile : Profile
    {
        public IdentityMapperProfile()
        {
            CreateMap<NixWebApplicationUser, NixWebApplicationUserDTO>()
               .ForMember(i => i.Id, i => i.MapFrom(j => j.Id))
               .ReverseMap();
        }
    }
}
