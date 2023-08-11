using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.BedRoomRoom.CreateCity;
using UniveristyLifeApp.Models.v1.BedRoomRoom.DeleteBedRoomRoom;
using UniveristyLifeApp.Models.v1.BedRoomRoom.GetBedRoomRoom;
using UniveristyLifeApp.Models.v1.BedRoomRoom.UpdateBedRoomRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Commands.CreateBedRoomRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Commands.DeleteBedRoomRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Commands.UpdateBedRoomRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Queries.GetBedRoomRoom;

namespace UniversityLifeApp.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/bedroomroom")]
    [ApiVersion("1.0")]
    public class BedRoomRoomController : BaseController
    {
        private readonly IMediator _mediator;
        public BedRoomRoomController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost("create")]
        public async Task<ApiResult<CreateBedRoomRoomResponse>> Create(CreateBedRoomRoomRequest request)
            => await _mediator.Send(new CreateBedRoomRoomCommand(request));

        [HttpGet("get")]
        public async Task<ActionResult<List<GetBedRoomRoomResponse>>> Get()
            => (await _mediator.Send(new GetBedRoomRoomQuery())).Response;

        [HttpPut("{bedRoomRoomId}/update")]
        public async Task<ApiResult<UpdateBedRoomRoomResponse>> Update(UpdateBedRoomRoomRequest request, int bedRoomRoomId)
            => await _mediator.Send(new UpdateBedRoomRoomCommand(request, bedRoomRoomId));

        [HttpDelete("{bedRoomRoomId}/delete")]
        public async Task<ApiResult<DeleteBedRoomRoomResponse>> Delete(int bedRoomRoomId)
            => await _mediator.Send(new DeleteBedRoomRoomCommand(bedRoomRoomId));
    }
}
