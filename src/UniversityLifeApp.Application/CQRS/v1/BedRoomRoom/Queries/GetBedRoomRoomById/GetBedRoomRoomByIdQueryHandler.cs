using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoom.GetBedRoomRoomById;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Queries.GetBedRoomRoomById
{
    public class GetBedRoomRoomByIdQueryHandler : IRequestHandler<GetBedRoomRoomByIdQuery, ApiResult<GetBedRoomRoomByIdResponse>>
    {
        private readonly IBedRoomRoomService _bedRoomRoomService;
        public GetBedRoomRoomByIdQueryHandler(IBedRoomRoomService bedRoomRoomService)
        {
            _bedRoomRoomService = bedRoomRoomService;
        }
        public async Task<ApiResult<GetBedRoomRoomByIdResponse>> Handle(GetBedRoomRoomByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _bedRoomRoomService.GetBedRoomRoomById(request.BedRoomRoomId);

            return result;
        }
    }
}
