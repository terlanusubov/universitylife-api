using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.Countries.AddCountry;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.Countryies.Commands.AddCountry;

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
    }
}
