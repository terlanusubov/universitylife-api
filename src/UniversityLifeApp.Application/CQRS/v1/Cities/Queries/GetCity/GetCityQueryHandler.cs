using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCity
{
    public class GetCityQueryHandler : IRequestHandler<GetCityQuery, ApiResult<List<GetCityResponse>>>
    {
        private readonly ICityService _cityService;
        public GetCityQueryHandler(ICityService cityService)
        {
            _cityService = cityService;
        }
        public async Task<ApiResult<List<GetCityResponse>>> Handle(GetCityQuery request, CancellationToken cancellationToken)
        {
            var result = await _cityService.GetCity();

            return result;
        }
    }
}
