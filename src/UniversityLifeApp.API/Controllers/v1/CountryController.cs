using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.Countries.AddCountry;
using UniveristyLifeApp.Models.v1.Countries.DeleteCountry;
using UniveristyLifeApp.Models.v1.Countries.GetCountry;
using UniveristyLifeApp.Models.v1.Countries.UpdateCountrt;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.Countryies.Commands.AddCountry;
using UniversityLifeApp.Application.CQRS.v1.Countryies.Commands.DeleteCountry;
using UniversityLifeApp.Application.CQRS.v1.Countryies.Commands.UpdateCountry;
using UniversityLifeApp.Application.CQRS.v1.Countryies.Query.GetCountry;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/countries")]
    [ApiVersion("1.0")]
    public class CountryController : BaseController
    {
        private readonly IMediator _mediator;
       
        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("addCountry")]
        public async Task<ApiResult<AddCountryResponse>> AddCity(AddCountryRequest request)
            => await _mediator.Send(new AddCountryCommand(request));

        [HttpGet("getCountry")]
        public async Task<ActionResult<List<GetCountryResponse>>> GetCity()
           => (await _mediator.Send(new GetCountryQuery())).Response;

        [HttpPut("{countryId}/update")]
        public async Task<ApiResult<UpdateCountryResponse>> UpdateCity(UpdateCountryRequest request, int countryId)
          => await _mediator.Send(new UpdateCountryCommand(request, countryId));

        [HttpDelete("{countryId}")]
        public async Task<ApiResult<DeleteCountryResponse>> DeleteCity(int countryId)
            => await _mediator.Send(new DeleteCountryCommand(countryId));

    }
}   
