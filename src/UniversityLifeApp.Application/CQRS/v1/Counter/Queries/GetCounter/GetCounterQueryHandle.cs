using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Counter.GetCounter;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.Counter.Queries.GetCounter
{
    public class GetCounterQueryHandle : IRequestHandler<GetCounterQuery, ApiResult<GetCounterResponse>>
    {
        private readonly ICounterService _counterService;

        public GetCounterQueryHandle(ICounterService counterService)
        {
            _counterService = counterService;
        }
        public Task<ApiResult<GetCounterResponse>> Handle(GetCounterQuery request, CancellationToken cancellationToken)
        {
            var result = _counterService.GetCounter();
            return result;
        }
    }
}
