using AutoMapper;
using NixWebApplication.BLL.DTO;
using NixWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixWebApplication.Mappers
{
    public class PriceToCategoryDTOMapperProfile : Profile
    {
        public PriceToCategoryDTOMapperProfile()
        {
            CreateMap<PriceToCategoryDTO, PriceToCategoryModel>()
                .ForMember(i => i.Id, i => i.MapFrom(j => j.Id))
                .ForMember(i => i.PriceCategory, i => i.MapFrom(j => j.PriceCategory))
                .ForMember(i => i.Price, i => i.MapFrom(j => j.Price))
                .ForMember(i => i.StartDate, i => i.MapFrom(j => j.StartDate))
                .ForMember(i => i.EndDate, i => i.MapFrom(j => j.EndDate))
                .ForMember(i => i.ApplicationUser, i => i.MapFrom(j => j.ApplicationUser))
                .ForMember(i => i.TimeStamp, i => i.MapFrom(j => j.TimeStamp))
                .ReverseMap();
        }
    }
}
