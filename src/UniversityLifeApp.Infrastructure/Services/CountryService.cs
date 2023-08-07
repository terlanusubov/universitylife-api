using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Countries.AddCountry;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.Countryies.Commands.AddCountry;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class CountryService : ICountryService
    {
        private readonly ApplicationContext _applicationContext;

        public CountryService(ApplicationContext applicationContext)
        {
           _applicationContext = applicationContext;
        }
        public async Task<ApiResult<AddCountryResponse>> AddCountry(AddCountryCommand request)
        {
            Country country = new Country
            {
                Name = request.Request.Name,
                CountryStatusId = request.Request.CountryStatisId,
                Cities = (ICollection<City>)request.Request.CiytEs,
            };
            await _applicationContext.Countries.AddAsync(country);
            await _applicationContext.SaveChangesAsync();

            var response = new AddCountryResponse
            {
                Name = country.Name,
                CountryStatisId = country.CountryStatusId,
                CiytEs = (ICollection<string>)country.Cities,
            };

            return ApiResult<AddCountryResponse>.Ok(response);
        }
    }
}
