using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.BedRoom.CreateBedRoom;
using UniveristyLifeApp.Models.v1.BedRoom.DeleteBedRoom;
using UniveristyLifeApp.Models.v1.BedRoom.GetBedRoom;
using UniveristyLifeApp.Models.v1.BedRoom.GetBedRoomById;
using UniveristyLifeApp.Models.v1.BedRoom.UpdateBedRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.BedRoom.Commands.CreateBedRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoom.Commands.DeleteBedRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoom.Commands.UpdateBedRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoom.Queries.GetBedRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoom.Queries.GetBedRoomById;

namespace UniversityLifeApp.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/bedroom")]
    [ApiVersion("1.0")]
    public class BedRoomController : BaseController
    {
        private readonly IMediator _mediator;
        public BedRoomController(IMediator mediator)
            => _mediator = mediator;


        [HttpPost]
        public async Task<ApiResult<CreateBedRoomResponse>> CreateBedRoom([FromForm]CreateBedRoomRequest request)
            => await _mediator.Send(new CreateBedRoomCommand(request));

        [HttpGet]
        public async Task<ApiResult<List<GetBedRoomResponse>>> GetBedRoom([FromQuery] GetBedRoomRequest request)
            => await _mediator.Send(new GetBedRoomQuery(request));

        [HttpGet("{bedroomId}")]
        public async Task<ApiResult<GetBedRoomByIdResponse>> GetBedRoomById(int bedroomId)
            => await _mediator.Send(new GetBedRoomByIdQuery(bedroomId));


        [HttpPut("{bedroomId}")]
        public async Task<ApiResult<UpdateBedRoomResponse>> UpdateBedRoom([FromForm]UpdateBedRoomRequest request ,int bedroomId)
            => await _mediator.Send(new UpdateBedRoomCommand(request,bedroomId));

        [HttpDelete("{bedroomId}")]
        public async Task<ApiResult<DeleteBedRoomResponse>> DeleteBedRoom(int bedroomId)
            => await _mediator.Send(new DeleteBedRoomCommand(bedroomId));

    }
}
