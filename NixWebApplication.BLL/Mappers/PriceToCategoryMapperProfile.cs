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
    class PriceToCategoryMapperProfile : Profile
    {
        public PriceToCategoryMapperProfile()
        {
            CreateMap<PriceToCategory, PriceToCategoryDTO>()
               .ForMember(i => i.Id, i => i.MapFrom(j => j.Id))
               .ForMember(i => i.PriceCategory, i => i.MapFrom(j => j.PriceCategory))
               .ForMember(i => i.Price, i => i.MapFrom(j => j.Price))
               .ForMember(i => i.StartDate, i => i.MapFrom(j => j.StartDate))
               .ForMember(i => i.EndDate, i => i.MapFrom(j => j.EndDate))
               .ReverseMap();
        }
    }
}
