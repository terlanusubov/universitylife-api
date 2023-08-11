using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.University.GetUniversityById;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.University.Queries.GetUniversityById
{
    public class GetUniversityByIdQueryHandler : IRequestHandler<GetUniversityByIdQuery, ApiResult<GetUniversityByIdResponse>>
    {
        private readonly IUniversityService _universityService;
        public GetUniversityByIdQueryHandler(IUniversityService universityService)
        {
            _universityService = universityService;
        }
        public async Task<ApiResult<GetUniversityByIdResponse>> Handle(GetUniversityByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _universityService.GetById(request.UniversityId);
            return result;
        }
    }
}
