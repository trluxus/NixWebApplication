using Microsoft.Extensions.DependencyInjection;
using NixWebApplication.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixWebApplication.Mapper.Utilities
{
    public static class IServiceCollectionExtension
    {
        public static void AddClientMapperConfigurations(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BookingDTOMapperProfile));
            services.AddAutoMapper(typeof(CategoryDTOMapperProfile));
            services.AddAutoMapper(typeof(GuestDTOMapperProfile));
            services.AddAutoMapper(typeof(PriceToCategoryDTOMapperProfile));
            services.AddAutoMapper(typeof(RoomDTOMapperProfile));
        }
    }
}
