using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.Cities.AddCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.AddCity;
using UniversityLifeApp.Application.Core;
using UniveristyLifeApp.Models.v1.Search;
using UniversityLifeApp.Application.CQRS.v1.Search.Commands.Search;

namespace UniversityLifeApp.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/search")]
    [ApiVersion("1.0")]
    public class SearchController : BaseController
    {
        private readonly IMediator _mediator;
        public SearchController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<ApiResult<List<SearchResponse>>>> Search(SearchRequest request)
            => await _mediator.Send(new SearchCommand(request));
    }
}
