using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.University.GetUniversity;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.University.Queries.GetUniversity
{
    public class GetUniversityQueryHandler : IRequestHandler<GetUniversityQuery, ApiResult<List<GetUniversityResponse>>>
    {
        private readonly IUniversityService _universityService;
        public GetUniversityQueryHandler(IUniversityService universityService)
        {
            _universityService = universityService;
        }
        public async Task<ApiResult<List<GetUniversityResponse>>> Handle(GetUniversityQuery request, CancellationToken cancellationToken)
        {
            var result = await _universityService.Get();

            return result;
        }
    }
}
