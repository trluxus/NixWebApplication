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
    class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<Category, CategoryDTO>()
                .ForMember(i => i.Id, i => i.MapFrom(j => j.Id))
                .ForMember(i => i.Name, i => i.MapFrom(j => j.Name))
                .ForMember(i => i.Beds, i => i.MapFrom(j => j.Beds))
                .ForMember(i => i.ApplicationUser, i => i.MapFrom(j => j.ApplicationUser))
                .ForMember(i => i.TimeStamp, i => i.MapFrom(j => j.TimeStamp))
                .ReverseMap();
        }     
    }
}
