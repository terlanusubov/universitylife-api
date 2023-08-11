using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Cities.DeleteCity;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.Cities.Commands.DeleteCity
{
    public class DeleteCityCommand:IRequest<ApiResult<DeleteCityResponse>>
    {
        public DeleteCityCommand(int cityId)
        {
            CityId = cityId;
        }
        public int CityId { get; set; }
    }
}
