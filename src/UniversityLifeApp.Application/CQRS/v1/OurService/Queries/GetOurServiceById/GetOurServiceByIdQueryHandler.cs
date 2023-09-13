using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.OurService.GetOurService;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.OurService.Queries.GetOurServiceById
{
    public class GetOurServiceByIdQueryHandler : IRequestHandler<GetOurServiceByIdQuery, ApiResult<GetOurServiceResponse>>
    {
        private readonly IOurServiceService _serviceService;
        public GetOurServiceByIdQueryHandler(IOurServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        public async Task<ApiResult<GetOurServiceResponse>> Handle(GetOurServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _serviceService.GetById(request.ServiceId);

            return result;
        }
    }
}
