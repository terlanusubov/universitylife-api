using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.Account.Login;
using UniveristyLifeApp.Models.v1.Account.Register;
using UniveristyLifeApp.Models.v1.Account.Update;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.Account.Commands.Login;
using UniversityLifeApp.Application.CQRS.v1.Account.Commands.Register;
using UniversityLifeApp.Application.CQRS.v1.Account.Commands.Update;

namespace UniversityLifeApp.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/account")]
    [ApiVersion("1.0")]
    public class AccountController : BaseController
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResult<RegisterResponse>>> Register([FromBody]RegisterRequest request)
            => await _mediator.Send(new RegisterCommand(request));

        [HttpPost("login")]
        public async Task<ActionResult<ApiResult<LoginResponse>>> Login([FromBody] LoginRequest request)
            => await _mediator.Send(new LoginCommand(request));

        [HttpPost("update")]
        public async Task<ActionResult<ApiResult<UpdateResponse>>> Update(UpdateRequest request)
            => await _mediator.Send(new UpdateCommand(request));

    }
}
