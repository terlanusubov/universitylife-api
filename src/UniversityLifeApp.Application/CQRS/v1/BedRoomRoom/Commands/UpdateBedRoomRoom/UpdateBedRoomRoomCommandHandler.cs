using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoom.UpdateBedRoomRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Commands.UpdateBedRoomRoom
{
    public class UpdateBedRoomRoomCommandHandler : IRequestHandler<UpdateBedRoomRoomCommand, ApiResult<UpdateBedRoomRoomResponse>>
    {
        private readonly IBedRoomRoomService _bedRoomRoomService;
        public UpdateBedRoomRoomCommandHandler(IBedRoomRoomService bedRoomRoomService)
            => _bedRoomRoomService = bedRoomRoomService;
        

        public async Task<ApiResult<UpdateBedRoomRoomResponse>> Handle(UpdateBedRoomRoomCommand request, CancellationToken cancellationToken)
        {
            var result = await _bedRoomRoomService.UpdateBedRoomRoom(request, request.BedRoomRoomId);

            return result;
        }
    }
}
