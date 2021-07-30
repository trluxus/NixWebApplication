using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NixWebApplication.BLL.Interfaces;
using NixWebApplication.BLL.Services;
using NixWebApplication.BLL.Utilities;
using NixWebApplication.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NixWebApplication.DAL.Repositories;
using NixWebApplication.API.Controllers;

namespace NixWebApplication.API
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NixAppContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), 
                b => b.MigrationsAssembly("NixWebApplication.API")));

            services.AddBLLServices();

            services.AddAutoMapper(typeof(BookingService), typeof(BookingController));
            services.AddAutoMapper(typeof(CategoryService), typeof(CategoryController));
            services.AddAutoMapper(typeof(GuestService), typeof(GuestController));
            services.AddAutoMapper(typeof(RoomService), typeof(RoomController));         

            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IGuestService, GuestService>(); 
            services.AddScoped<IRoomService, RoomService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
