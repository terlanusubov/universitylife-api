using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCity
{
    public class GetCityQuery:IRequest<ApiResult<List<GetCityResponse>>>
    {
        public GetCityQuery(GetCityRequest request)
        {
            Request = request;
        }

        public GetCityRequest Request { get; set; }

        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int CityStatusId { get; set; }
    }
}