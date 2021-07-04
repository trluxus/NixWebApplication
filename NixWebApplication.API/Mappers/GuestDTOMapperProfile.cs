﻿using AutoMapper;
using NixWebApplication.API.Models;
using NixWebApplication.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixWebApplication.API.Mappers
{
    public class GuestDTOMapperProfile : Profile
    {
        public GuestDTOMapperProfile()
        {
            CreateMap<GuestDTO, GuestModel>()
                .ForMember(i => i.Id, i => i.MapFrom(j => j.Id))
                .ForMember(i => i.Name, i => i.MapFrom(j => j.Name))
                .ForMember(i => i.Surname, i => i.MapFrom(j => j.Surname))
                .ForMember(i => i.Patronymic, i => i.MapFrom(j => j.Patronymic))
                .ForMember(i => i.BirthDate, i => i.MapFrom(j => j.BirthDate))
                .ForMember(i => i.Address, i => i.MapFrom(j => j.Address))
                .ReverseMap();
        }
    }
}
