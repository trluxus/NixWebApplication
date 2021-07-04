﻿using AutoMapper;
using NixWebApplication.API.Models;
using NixWebApplication.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixWebApplication.API.Mappers
{
    public class CategoryDTOMapperProfile : Profile
    {
        public CategoryDTOMapperProfile()
        {
            CreateMap<CategoryDTO, CategoryModel>()
                .ForMember(i => i.Id, i => i.MapFrom(j => j.Id))
                .ForMember(i => i.Name, i => i.MapFrom(j => j.Name))
                .ForMember(i => i.Beds, i => i.MapFrom(j => j.Beds))
                .ReverseMap();
        }
    }
}
