using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.Cities.AddCity;
using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.AddCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCity;

namespace UniversityLifeApp.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/cities")]
    [ApiVersion("1.0")]
    public class CityController : BaseController
    {
        private readonly IMediator _mediator;
        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("addcity")]
        public async Task<ApiResult<AddCityResponse>> AddCity(AddCityRequest request)
            => await _mediator.Send(new AddCityCommand(request));

        [HttpGet("getcity")]
        public async Task<ActionResult<List<GetCityResponse>>> GetCity()
            => (await _mediator.Send(new GetCityQuery())).Response;

    }
}
