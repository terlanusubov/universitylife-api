using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.CreateBedRoomRoomType;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.DeleteBedRoomRoomType;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.GetBedRoomRoomType;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.GetBedRoomRoomTypeById;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.UpdateBedRoomRoomType;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Commands.CreateBedRoomRoomType;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Commands.DeleteBedRoomRoomType;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Commands.UpdateBedRoomRoomType;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Queries.GetBedRoomRoomType;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Queries.GetBedRoomRoomTypeById;
using UniversityLifeApp.Domain.Entities;

namespace UniversityLifeApp.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/bedroomroomtype")]
    [ApiVersion("1.0")]
    public class BedRoomRoomTypeController : BaseController
    {
        private readonly IMediator _mediator;
        public BedRoomRoomTypeController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost("createbedroomroomtype")]
        public async Task<ApiResult<CreateBedRoomRoomTypeResponse>> CreateBedRoomRoomType(CreateBedRoomRoomTypeRequest request)
              => await _mediator.Send(new CreateBedRoomRoomTypeCommand(request));

        [HttpGet("getbedroomroomtype")]
        public async Task<ApiResult<List<GetBedRoomRoomTypeResponse>>> GetBedRoomRoomType()
            => await _mediator.Send(new GetBedRoomRoomTypeQuery());

        //[HttpGet("getbedroomroomtypebyid/{bedroomroomtypeId}")]
        //public async Task<ApiResult<GetBedRoomRoomTypeByIdResponse>> GetBedRoomRoomTypeById(int roomtypeId)
        //   => await _mediator.Send(new GetBedRoomRoomTypeByIdQuery(roomtypeId));

        [HttpPut("{bedroomroomtypeId}/updatebedroomroomtype")]
        public async Task<ApiResult<UpdateBedRoomRoomTypeResponse>> UpdateBedRoomRoomType(UpdateBedRoomRoomTypeRequest request, int roomtypeId)
           => await _mediator.Send(new UpdateBedRoomRoomTypeCommand(request, roomtypeId));

        [HttpDelete("{bedroomroomtypeId}/deletebedroomroomtype")]
        public async Task<ApiResult<DeleteBedRoomRoomTypeResponse>> DeleteBedRoomRoomType(int roomtypeId)
            => await _mediator.Send(new DeleteBedRoomRoomTypeCommand(roomtypeId));

    }
}
