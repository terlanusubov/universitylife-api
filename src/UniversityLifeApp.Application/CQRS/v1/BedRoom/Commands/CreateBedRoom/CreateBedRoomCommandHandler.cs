using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoom.CreateBedRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoom.Commands.CreateBedRoom
{
    public class CreateBedRoomCommandHandler : IRequestHandler<CreateBedRoomCommand, ApiResult<CreateBedRoomResponse>>
    {
        private readonly IBedRoomService _service;
        public CreateBedRoomCommandHandler(IBedRoomService service)
        {
            _service = service;
        }
        public async Task<ApiResult<CreateBedRoomResponse>> Handle(CreateBedRoomCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.CreateBedRoom(request);

            return result;
        }
    }
}
