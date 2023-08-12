using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.UserRole.CreateRole;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.UserRole.Commands.CreateUserRole;

namespace UniversityLifeApp.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/userrole")]
    [ApiVersion("1.0")]
    public class UserRoleController : BaseController
    {
        private readonly IMediator _mediator;
        public UserRoleController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost("create")]
        public async Task<ApiResult<UserRoleResponse>> Create(UserRoleRequest request)
            => await _mediator.Send(new CreateUserRoleCommand(request));
    }
}
