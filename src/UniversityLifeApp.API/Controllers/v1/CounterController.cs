using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.Contact.GetContact;
using UniveristyLifeApp.Models.v1.Counter.GetCounter;
using UniversityLifeApp.Application.CQRS.v1.Contact.Queries.GetContact;
using UniversityLifeApp.Application.CQRS.v1.Counter.Queries.GetCounter;

namespace UniversityLifeApp.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Counter")]
    [ApiVersion("1.0")]
    public class CounterController : BaseController
    {
        private readonly IMediator _mediator;

        public CounterController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<GetCounterResponse>> GetCount()
        => (await _mediator.Send(new GetCounterQuery())).Response;
    }
}
