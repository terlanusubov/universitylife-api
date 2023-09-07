using EEWF.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Infrastructure.Data;
using UniversityLifeApp.Infrastructure.Services;

namespace UniversityLifeApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IBedRoomService, BedRoomService>();
            services.AddTransient<IJWTService, JWTService>();
            services.AddTransient<IBedRoomPhotoService, BedRoomPhotoService>();
            services.AddTransient<IBedRoomRoomService, BedRoomRoomService>();
            services.AddTransient<IUniversityService, UniversityService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IFileService, FileService>();

            services.AddTransient<IContactService, ContactService>();

            services.AddTransient<ISearchService, SearchService>();

            services.AddTransient<IOurServiceService, OurServiceService>();
            services.AddTransient<ICounterService, CounterService>();   

            services.AddDbContext<ApplicationContext>(opt =>
            {
                opt.UseMySql(configuration.GetConnectionString("Default"), ServerVersion.AutoDetect(configuration.GetConnectionString("Default")));
            });


            return services;
        }
    }
}
