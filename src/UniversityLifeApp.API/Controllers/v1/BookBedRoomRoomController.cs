using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.CreateBookBedRoomRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.BookBedRoomRoom.Commands.CreateBookBedRoomRoom;

namespace UniversityLifeApp.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/book")]
    [ApiVersion("1.0")]
    public class BookBedRoomRoomController : BaseController
    {
        private readonly IMediator _mediator;
        public BookBedRoomRoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResult<CreateBookBedRoomRoomResponse>>> Create(CreateBookBedRoomRoomRequest request)
            => await _mediator.Send(new CreateBookBedRoomRoomCommand(request));
    }
}
