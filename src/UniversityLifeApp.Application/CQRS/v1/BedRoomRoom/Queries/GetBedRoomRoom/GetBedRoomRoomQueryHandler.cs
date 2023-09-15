using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoom.GetBedRoomRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Queries.GetBedRoomRoom
{
    public class GetBedRoomRoomQueryHandler : IRequestHandler<GetBedRoomRoomQuery, ApiResult<List<GetBedRoomRoomResponse>>>
    {
        private readonly IBedRoomRoomService _bedRoomRoomService;
        public GetBedRoomRoomQueryHandler(IBedRoomRoomService bedRoomRoomService)
            =>_bedRoomRoomService = bedRoomRoomService;
        
        public async Task<ApiResult<List<GetBedRoomRoomResponse>>> Handle(GetBedRoomRoomQuery request, CancellationToken cancellationToken)
        {
            var result = await _bedRoomRoomService.GetBedRoomRoom(request.Request);

            return result;
        }
    }
}
