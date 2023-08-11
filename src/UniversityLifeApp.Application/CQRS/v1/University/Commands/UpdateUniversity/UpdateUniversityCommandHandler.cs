using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.University.UpdateUniversity;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.University.Commands.UpdateUniversity
{
    public class UpdateUniversityCommandHandler : IRequestHandler<UpdateUniversityCommand, ApiResult<UpdateUniversityResponse>>
    {
        private readonly IUniversityService _universityService;
        public UpdateUniversityCommandHandler(IUniversityService universityService)
            => _universityService = universityService;

        public async Task<ApiResult<UpdateUniversityResponse>> Handle(UpdateUniversityCommand request, CancellationToken cancellationToken)
        {
            var result = await _universityService.Update(request, request.UniversityId);

            return result;
        }
    }
}
