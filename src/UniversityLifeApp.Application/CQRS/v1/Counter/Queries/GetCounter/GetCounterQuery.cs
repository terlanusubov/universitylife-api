using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Counter.GetCounter;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.Counter.Queries.GetCounter
{
    public class GetCounterQuery:IRequest<ApiResult<GetCounterResponse>>
    {
        public int StudentCount { get; set; }
        public int CityCount { get; set; }
        public int BedRoomCount { get; set; }
        public int UniversityCount { get; set; }
    }
}
