using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UniversityLifeApp.API.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        public IMediator Mediator { get => _mediator ?? HttpContext.RequestServices.GetRequiredService<IMediator>(); }
        private readonly IMediator _mediator;
    }
}

