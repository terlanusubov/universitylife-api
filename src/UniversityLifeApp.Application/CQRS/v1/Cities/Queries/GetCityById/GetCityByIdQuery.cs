using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Cities.GetCityById;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCityById
{
    public class GetCityByIdQuery:IRequest<ApiResult<GetCityByIdResponse>>
    {
        public GetCityByIdQuery(int cityId)
        {
            CityId = cityId;
        }
        public int CityId { get; set; }
    }
}
