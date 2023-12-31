﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.OurService.CreateOurService;
using UniveristyLifeApp.Models.v1.OurService.GetOurService;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.OurService.Commands.CreateService;
using UniversityLifeApp.Application.CQRS.v1.OurService.Queries.GetOurService;

namespace UniversityLifeApp.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/ourservice")]
    [ApiVersion("1.0")]
    public class OurServiceController : BaseController
    {
        private readonly IMediator _mediator;
        public OurServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResult<CreateOurServiceResponse>>> CreateService([FromForm]CreateOurServiceRequest request)
            => await _mediator.Send(new CreateServiceCommand(request));

        [HttpGet]
        public async Task<ActionResult<List<GetOurServiceResponse>>> GetOurServices()
            => (await _mediator.Send( new GetOurServiceQuery())).Response;
        
    }
}
