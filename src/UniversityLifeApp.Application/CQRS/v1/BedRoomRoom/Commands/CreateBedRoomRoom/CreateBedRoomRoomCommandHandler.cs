using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoom.CreateCity;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Commands.CreateBedRoomRoom
{
    public class CreateBedRoomRoomCommandHandler : IRequestHandler<CreateBedRoomRoomCommand, ApiResult<CreateBedRoomRoomResponse>>
    {
        private readonly IBedRoomRoomService _bedRoomRoomService;
        public CreateBedRoomRoomCommandHandler(IBedRoomRoomService bedRoomRoomService)
        {
            _bedRoomRoomService = bedRoomRoomService;
        }
        public async Task<ApiResult<CreateBedRoomRoomResponse>> Handle(CreateBedRoomRoomCommand request, CancellationToken cancellationToken)
        {
            var result = await _bedRoomRoomService.CreateBedRoomRoom(request);

            return result;
        }
    }
}