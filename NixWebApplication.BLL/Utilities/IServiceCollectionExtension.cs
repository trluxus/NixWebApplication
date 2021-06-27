using Microsoft.Extensions.DependencyInjection;
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
        public static IServiceCollection AddBLLServices(this IServiceCollection services)
        {
            services.AddScoped<IWorkUnit, EFWorkUnit>();

            return services;
        }
    }
}
