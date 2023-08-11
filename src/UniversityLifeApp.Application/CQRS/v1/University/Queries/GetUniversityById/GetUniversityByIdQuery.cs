using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.University.GetUniversityById;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.University.Queries.GetUniversityById
{
    public class GetUniversityByIdQuery:IRequest<ApiResult<GetUniversityByIdResponse>>
    {
        public GetUniversityByIdQuery(int universityId)
        {
            UniversityId = universityId;
        }
        public int UniversityId { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int UniversityStatusId { get; set; }

        //City
        public int CityId { get; set; }
    }
}
