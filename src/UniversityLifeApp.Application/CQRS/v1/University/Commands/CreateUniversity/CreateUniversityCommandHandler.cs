using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.University.CreateUniversity;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.University.Commands.CreateUniversity
{
    public class CreateUniversityCommandHandler : IRequestHandler<CreateUniversityCommand, ApiResult<CreateUniversityResponse>>
    {
        private readonly IUniversityService _universityService;
        public CreateUniversityCommandHandler(IUniversityService universityService)
            => _universityService = universityService;

        public async Task<ApiResult<CreateUniversityResponse>> Handle(CreateUniversityCommand request, CancellationToken cancellationToken)
        {
            var result = await _universityService.Create(request);

            return result;
        }
    }
}
