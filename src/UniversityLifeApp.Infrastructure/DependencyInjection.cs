﻿using EEWF.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoom.GetBedRoom;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Application.Interfaces.Admin;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Infrastructure.Data;
using UniversityLifeApp.Infrastructure.Services;
using UniversityLifeApp.Infrastructure.Services.Admin;

namespace UniversityLifeApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddTransient<IBedRoomRoomTypeRoomTypeService,BedRoomRoomTypeService>();

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAdminAccountService, AdminAccountService>();
            services.AddTransient<IBedRoomService, BedRoomService>();
            services.AddTransient<IJWTService, JWTService>();
            services.AddTransient<IBedRoomPhotoService, BedRoomPhotoService>();
            services.AddTransient<IBedRoomRoomService, BedRoomRoomService>();
            services.AddTransient<IUniversityService, UniversityService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IUserWishlistService, UserWishlistService>();
            services.AddTransient<IBookBedRoomRoom, BookBedRoomRoomService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<ISearchService, SearchService>();
            services.AddTransient<IOurServiceService, OurServiceService>();
            services.AddTransient<ICounterService, CounterService>();

            services.AddSession();
            services.AddHttpContextAccessor();

            services.AddDbContext<ApplicationContext>(opt =>
            {
                opt.UseMySql(configuration.GetConnectionString("Default"), ServerVersion.AutoDetect(configuration.GetConnectionString("Default")));
            });


            return services;
        }
    }
}
