using Microsoft.Extensions.DependencyInjection;
using NixWebApplication.BLL.Mappers;
using NixWebApplication.BLL.Services;
using NixWebApplication.DAL.Interfaces;
using NixWebApplication.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixWebApplication.BLL.Utilities
{
    public static class IServiceCollectionExtension
    {
        public static void AddBLLServices(this IServiceCollection services)
        {
            services.AddScoped<IWorkUnit, EFWorkUnit>();

            services.AddAutoMapper(typeof(BookingMapperProfile));
            services.AddAutoMapper(typeof(CategoryMapperProfile));
            services.AddAutoMapper(typeof(GuestMapperProfile));
            services.AddAutoMapper(typeof(PriceToCategoryMapperProfile));
            services.AddAutoMapper(typeof(RoomMapperProfile));
        }
    }
}
