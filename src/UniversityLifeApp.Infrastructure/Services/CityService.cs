using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Cities.AddCity;
using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.AddCity;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Domain.Enums;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class CityService : ICityService
    {
        private readonly ApplicationContext _context;
        public CityService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<AddCityResponse>> AddCity(AddCityCommand request)
        {
            City city = new City
            {
                Name = request.Request.Name,
                CityStatusId = (int)CityStatusEnum.Active,
                CountryId = request.Request.CountryId,
                Latitude = request.Request.Latitude,
                Longitude = request.Request.Longitude,
            };

            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();

            var response = new AddCityResponse
            {
                Name = city.Name,
                CountryId = city.CountryId,
                Latitude = city.Latitude,
                Longitude = city.Longitude,
                CityStatusId = city.CityStatusId,
            };

            return ApiResult<AddCityResponse>.OK(response);
        }

        public async Task<ApiResult<List<GetCityResponse>>> GetCity()
        {
            var cities = await _context.Cities.Where(x => x.CityStatusId == (int)CityStatusEnum.Active).Select(x => new GetCityResponse
            {
                Name = x.Name,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                CountryId = x.CountryId,
            }).ToListAsync();

            return ApiResult<List<GetCityResponse>>.OK(cities);
        }
    }
}
