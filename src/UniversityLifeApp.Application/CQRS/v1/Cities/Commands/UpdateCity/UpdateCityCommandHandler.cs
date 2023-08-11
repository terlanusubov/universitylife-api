using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Cities.UpdateCity;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.Cities.Commands.UpdateCity
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, ApiResult<UpdateCityResponse>>
    {
        private readonly ICityService _cityService;
        public UpdateCityCommandHandler(ICityService cityService)
        {
            _cityService = cityService;
        }
        public async Task<ApiResult<UpdateCityResponse>> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var result = await _cityService.UpdateCity(request, request.CityId);

            return result;
        }
    }
}
