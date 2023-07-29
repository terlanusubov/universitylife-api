using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.Account.Register;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.Account.Commands.Register;

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


    }
}
