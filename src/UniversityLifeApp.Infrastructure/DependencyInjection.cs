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
            services.AddDbContext<ApplicationContext>(opt =>
            {
                opt.UseMySql(configuration.GetConnectionString("Default"), ServerVersion.AutoDetect(configuration.GetConnectionString("Default")));
            });


            return services;
        }
    }
}
