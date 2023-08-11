using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoom.DeleteBedRoomRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Commands.DeleteBedRoomRoom
{
    public class DeleteBedRoomRoomCommandHandler : IRequestHandler<DeleteBedRoomRoomCommand, ApiResult<DeleteBedRoomRoomResponse>>
    {
        private readonly IBedRoomRoomService _bedRoomRoomService;
        public DeleteBedRoomRoomCommandHandler(IBedRoomRoomService bedRoomRoomService)
            => _bedRoomRoomService = bedRoomRoomService;

        public async Task<ApiResult<DeleteBedRoomRoomResponse>> Handle(DeleteBedRoomRoomCommand request, CancellationToken cancellationToken)
        {
            var result = await _bedRoomRoomService.Delete(request.BedRoomRoomId);

            return result;
        }
    }
}
