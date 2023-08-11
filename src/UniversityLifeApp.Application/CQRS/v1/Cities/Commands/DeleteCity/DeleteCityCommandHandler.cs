using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Cities.DeleteCity;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.Cities.Commands.DeleteCity
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, ApiResult<DeleteCityResponse>>
    {
        private readonly ICityService _cityService;
        public DeleteCityCommandHandler(ICityService cityService)
        {
            _cityService = cityService;
        }
        public async Task<ApiResult<DeleteCityResponse>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var result = await _cityService.DeleteCity(request.CityId);

            return result;
        }
    }
}
