using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.Cities.AddCity;
using UniveristyLifeApp.Models.v1.Cities.DeleteCity;
using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniveristyLifeApp.Models.v1.Cities.GetCityById;
using UniveristyLifeApp.Models.v1.Cities.UpdateCity;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.AddCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.DeleteCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.UpdateCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCityById;

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
        [HttpPost]
        public async Task<ApiResult<AddCityResponse>> AddCity([FromForm]AddCityRequest request)
            => await _mediator.Send(new AddCityCommand(request));

        [HttpGet]
        public async Task<ActionResult<List<GetCityResponse>>> GetCity([FromQuery]GetCityRequest request)
            => (await _mediator.Send(new GetCityQuery(request))).Response;

        [HttpGet("{cityId}")]
        public async Task<ActionResult<GetCityByIdResponse>> GetCity(int cityId)
            => (await _mediator.Send(new GetCityByIdQuery(cityId))).Response;

        [HttpPut("{cityId}")]
        public async Task<ApiResult<UpdateCityResponse>> UpdateCity(UpdateCityRequest request, int cityId)
            => await _mediator.Send(new UpdateCityCommand(request, cityId));

        [HttpDelete("{cityId}")]
        public async Task<ApiResult<DeleteCityResponse>> DeleteCity(int cityId)
            => await _mediator.Send(new DeleteCityCommand(cityId));
    }
}