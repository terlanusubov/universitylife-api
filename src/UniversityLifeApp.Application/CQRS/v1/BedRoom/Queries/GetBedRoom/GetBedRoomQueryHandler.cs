using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoom.GetBedRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoom.Queries.GetBedRoom
{
    public class GetBedRoomQueryHandler : IRequestHandler<GetBedRoomQuery, ApiResult<GetBedRoomResponse>>
    {
        private readonly IBedRoomService _service;
        public GetBedRoomQueryHandler(IBedRoomService service)
        {
            _service = service;
        }
        public async Task<ApiResult<GetBedRoomResponse>> Handle(GetBedRoomQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetBedRoom(request.Request);
            return result;
            
        }
    }
}
