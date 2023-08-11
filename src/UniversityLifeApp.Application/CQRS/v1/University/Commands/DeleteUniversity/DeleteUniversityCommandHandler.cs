using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.University.DeleteUniversity;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.University.Commands.DeleteUniversity
{
    public class DeleteUniversityCommandHandler : IRequestHandler<DeleteUniversityCommand, ApiResult<DeleteUniversityResponse>>
    {
        private readonly IUniversityService _universityService;
        public DeleteUniversityCommandHandler(IUniversityService universityService)
        {
            _universityService = universityService;
        }
        public async Task<ApiResult<DeleteUniversityResponse>> Handle(DeleteUniversityCommand request, CancellationToken cancellationToken)
        {
            var result = await _universityService.Delete(request.UniversityId);

            return result;
        }
    }
}
