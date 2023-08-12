using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoom.GetBedRoomById;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoom.Queries.GetBedRoomById
{
    public class GetBedRoomByIdQueryHandler : IRequestHandler<GetBedRoomByIdQuery, ApiResult<GetBedRoomByIdResponse>>
    {
        private readonly IBedRoomService _service;
        public GetBedRoomByIdQueryHandler(IBedRoomService service)
        {
            _service = service;
        }
        public Task<ApiResult<GetBedRoomByIdResponse>> Handle(GetBedRoomByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _service.GetBedRoomById(request.BedRoomId);
            return result;
        }
    }
}
