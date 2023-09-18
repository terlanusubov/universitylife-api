using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.GetBedRoomRoomTypeById;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Queries.GetBedRoomRoomTypeById
{
    public class GetBedRoomRoomTypeByIdQueryHandler : IRequestHandler<GetBedRoomRoomTypeByIdQuery, ApiResult<GetBedRoomRoomTypeByIdResponse>>
    {
        private readonly IBedRoomRoomTypeRoomTypeService _service;
        public GetBedRoomRoomTypeByIdQueryHandler(IBedRoomRoomTypeRoomTypeService service)
        {
            _service = service;
        }
        public async Task<ApiResult<GetBedRoomRoomTypeByIdResponse>> Handle(GetBedRoomRoomTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetBedRoomRoomTypeById(request.RoomTypeId);
            return result;
        }
    }
}
