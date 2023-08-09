using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoom.UpdateBedRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoom.Commands.UpdateBedRoom
{
    public class UpdateBedRoomCommandHandler : IRequestHandler<UpdateBedRoomCommand, ApiResult<UpdateBedRoomResponse>>
    {
        private readonly IBedRoomService _service;
        public UpdateBedRoomCommandHandler(IBedRoomService service)
        {
            _service = service;
        }
        public async Task<ApiResult<UpdateBedRoomResponse>> Handle(UpdateBedRoomCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.UpdateBedRoom(request , request.BedRoomId);
            return result;
        }
    }
}
