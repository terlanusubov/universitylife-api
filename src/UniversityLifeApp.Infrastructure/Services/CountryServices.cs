using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Countries.AddCountry;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class CountryServices : ICountryService
    {
        private readonly ApplicationContext _context;

        public CountryServices(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<CountryResponse>> CreateCountry(CountryRequest request)
        {
            Country country = new Country
            {
                Name = request.Name,
                Cities = (ICollection<City>)request.Cities,
                CountryStatusId = request.CountryStatusId,
            };
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
            var response = new CountryResponse
            {
                Name = request.Name,
                CountryStatusId = request.CountryStatusId,
                Cities = request.Cities
            };

            return ApiResult<CountryResponse>.Ok(response);
        }
    }
}
