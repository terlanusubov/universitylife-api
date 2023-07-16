using System;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.Users.AddUser;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.Users.Commands.AddUser;

namespace UniversityLifeApp.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/users")]
    [ApiVersion("1.0")]
    public class UserController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<ApiResult<AddUserResponse>>> Get(AddUserRequest request)
            => await Mediator.Send(new AddUserCommand(request));

    }
}

