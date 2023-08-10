using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.University.CreateUniversity;
using UniveristyLifeApp.Models.v1.University.DeleteUniversity;
using UniveristyLifeApp.Models.v1.University.GetUniversity;
using UniveristyLifeApp.Models.v1.University.UpdateUniversity;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.University.Commands.CreateUniversity;
using UniversityLifeApp.Application.CQRS.v1.University.Commands.DeleteUniversity;
using UniversityLifeApp.Application.CQRS.v1.University.Commands.UpdateUniversity;
using UniversityLifeApp.Application.CQRS.v1.University.Queries.GetUniversity;

namespace UniversityLifeApp.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/university")]
    [ApiVersion("1.0")]
    public class UniversityController : BaseController
    {
        private readonly IMediator _mediator;
        public UniversityController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost("create")]
        public async Task<ApiResult<CreateUniversityResponse>> Create(CreateUniversityRequest request)
            => await _mediator.Send(new CreateUniversityCommand(request));

        [HttpPut("{universityId}/update")]
        public async Task<ApiResult<UpdateUniversityResponse>> Update(UpdateUniversityRequest request, int universityId)
            => await _mediator.Send(new UpdateUniversityCommand(request, universityId));

        [HttpGet("get")]
        public async Task<ApiResult<List<GetUniversityResponse>>> Get()
            => await _mediator.Send(new GetUniversityQuery());

        [HttpDelete("{universityId}/delete")]
        public async Task<ApiResult<DeleteUniversityResponse>> Delete(int universityId)
            => await _mediator.Send(new DeleteUniversityCommand(universityId));
    }
}
