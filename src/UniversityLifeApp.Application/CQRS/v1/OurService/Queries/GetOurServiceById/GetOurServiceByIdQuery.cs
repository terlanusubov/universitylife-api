using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.OurService.GetOurService;
using UniveristyLifeApp.Models.v1.OurService.GetOurServiceById;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.OurService.Queries.GetOurServiceById
{
    public class GetOurServiceByIdQuery:IRequest<ApiResult<GetOurServiceResponse>>
    {
        public GetOurServiceByIdQuery(int serviceId)
        {
            ServiceId = serviceId;
        }

        public int ServiceId { get; set; }
    }
}
