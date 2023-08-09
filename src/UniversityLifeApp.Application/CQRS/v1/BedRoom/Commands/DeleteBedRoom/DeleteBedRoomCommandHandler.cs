using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoom.DeleteBedRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoom.Commands.DeleteBedRoom
{
    public class DeleteBedRoomCommandHandler : IRequestHandler<DeleteBedRoomCommand, ApiResult<DeleteBedRoomResponse>>
    {
        private readonly IBedRoomService _service;
        public DeleteBedRoomCommandHandler(IBedRoomService service)
        {
            _service = service; 
        }
        public Task<ApiResult<DeleteBedRoomResponse>> Handle(DeleteBedRoomCommand request, CancellationToken cancellationToken)
        {
            var result = _service.DeleteBedRoom(request.BedRoomId);
            return result;
        }
    }
}
