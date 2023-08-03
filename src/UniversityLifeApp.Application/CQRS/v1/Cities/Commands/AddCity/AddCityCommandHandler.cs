using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Cities.AddCity;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.Cities.Commands.AddCity
{
    public class AddCityCommandHandler : IRequestHandler<AddCityCommand, ApiResult<AddCityResponse>>
    {
        private readonly ICityService _cityService;
        public AddCityCommandHandler(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<ApiResult<AddCityResponse>> Handle(AddCityCommand request, CancellationToken cancellationToken)
        {
            var result = await _cityService.AddCity(request);

            return result;

        }
    }
}
