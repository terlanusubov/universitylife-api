using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.OurService.GetOurService;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.OurService.Queries.GetOurService
{
    public class GetOurServiceQueryHandler : IRequestHandler<GetOurServiceQuery, ApiResult<List<GetOurServiceResponse>>>
    {
        private readonly IOurServiceService _service;
        public GetOurServiceQueryHandler(IOurServiceService service)
            => _service = service;
       
        public async Task<ApiResult<List<GetOurServiceResponse>>> Handle(GetOurServiceQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetOurService();
            return result;
        }
    }
}
