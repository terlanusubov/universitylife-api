using Microsoft.EntityFrameworkCore;
using UniveristyLifeApp.Models.v1.Countries.AddCountry;
using UniveristyLifeApp.Models.v1.Countries.DeleteCountry;
using UniveristyLifeApp.Models.v1.Countries.GetCountry;
using UniveristyLifeApp.Models.v1.Countries.UpdateCountrt;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.Countryies.Commands.AddCountry;
using UniversityLifeApp.Application.CQRS.v1.Countryies.Commands.UpdateCountry;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Domain.Enums;
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


        public async Task<ApiResult<List<GetCountryResponse>>> GetCountry()
        {
            var country = await _applicationContext.Countries.Where(x => x.CountryStatusId == 10).Select(x => new GetCountryResponse
            {
                Name = x.Name,
                CountryStatisId = x.CountryStatusId,
                CiytEs = (ICollection<string>)x.Cities
            }).ToListAsync();
            return ApiResult<List<GetCountryResponse>>.Ok(country);
        }

        public async Task<ApiResult<UpdateCountryResponse>> UpdateCountry(UpdateCountryCommand request, int cityId)
        {
            var country = await _applicationContext.Countries.Where(x => x.Id == cityId).FirstOrDefaultAsync();
            country.Name = request.Request.Name;
            country.CountryStatusId = request.Request.CountryStatisId;
            country.Cities = (ICollection<City>)request.Request.CiytEs;
            await _applicationContext.SaveChangesAsync();

            var response = new UpdateCountryResponse
            {
                Name = country.Name,
                CountryStatisId = country.CountryStatusId,
                CiytEs = (ICollection<string>)country.Cities
            };
            return ApiResult<UpdateCountryResponse>.Ok(response);
        }
        public async Task<ApiResult<DeleteCountryResponse>> DeleteCountry(int countryId)
        {
            var country = await _applicationContext.Countries.Where(x => x.Id == countryId).FirstOrDefaultAsync();

            country.CountryStatusId = (int)CountryStatusEnum.Deactive;

            await _applicationContext.SaveChangesAsync();

            var response = new DeleteCountryResponse
            {
                CountryId = country.Id
            };

            return ApiResult<DeleteCountryResponse>.Ok(response);
        }
    }
}
