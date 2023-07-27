using System;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using UniveristyLifeApp.Models.v1.Users.AddUser;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.Users.Commands.AddUser;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/users")]
    [ApiVersion("1.0")]
    public class UserController : BaseController
    {
        private readonly ILogger<UserController> _logger;
        private readonly ApplicationContext _context;
        public UserController(ILogger<UserController> logger, ApplicationContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResult<AddUserResponse>>> Get(AddUserRequest request)
        {
            Log.Information("salam");
             await Mediator.Send(new AddUserCommand(request));
            return Ok();
        }

    }
}

