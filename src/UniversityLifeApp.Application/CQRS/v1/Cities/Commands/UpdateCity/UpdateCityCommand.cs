using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Cities.UpdateCity;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.Cities.Commands.UpdateCity
{
    public class UpdateCityCommand:IRequest<ApiResult<UpdateCityResponse>>
    {
        public UpdateCityCommand(UpdateCityRequest request, int cityId)
        {
            Request = request;
            CityId = cityId;
        }

        public UpdateCityRequest Request { get; set; }
        public int CityId { get; set; }
    }
}