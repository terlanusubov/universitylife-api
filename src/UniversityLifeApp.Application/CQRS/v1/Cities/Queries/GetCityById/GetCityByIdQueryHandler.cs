using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Cities.GetCityById;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCityById
{
    public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, ApiResult<GetCityByIdResponse>>
    {
        private readonly ICityService _cityService;
        public GetCityByIdQueryHandler(ICityService cityService)
        {
            _cityService = cityService;
        }
        public async Task<ApiResult<GetCityByIdResponse>> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _cityService.GetCityById(request.CityId);

            return result;
        }
    }
}
