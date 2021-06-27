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
    class GuestServiceMapperProfile : Profile
    {
        public GuestServiceMapperProfile()
        {
            CreateMap<Guest, GuestDTO>().ReverseMap();
        }
    }
}
