using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.CloseBedRoom.GetCloseBedRoom;
using UniveristyLifeApp.Models.v1.Countries.GetCountry;
using UniversityLifeApp.Application.CQRS.v1.CloseBedRoom.Queries.GetCloseBedroom;
using UniversityLifeApp.Application.CQRS.v1.Countryies.Query.GetCountry;

namespace UniversityLifeApp.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/GetCloseBedRoom")]
    [ApiVersion("1.0")]
    public class GetCloseBedRoomController : BaseController
    {
        private readonly IMediator _mediator;

        public GetCloseBedRoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetCloseBedRoomResponse>> GetCity(int universityId)
           => (await _mediator.Send(new GetCloseBedRoomQuery(universityId))).Response;
    }
}
