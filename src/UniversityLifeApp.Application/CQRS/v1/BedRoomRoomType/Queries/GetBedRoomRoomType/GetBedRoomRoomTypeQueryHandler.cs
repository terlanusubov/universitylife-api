using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.GetBedRoomRoomType;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Queries.GetBedRoomRoomType
{
    public class GetBedRoomRoomTypeQueryHandler : IRequestHandler<GetBedRoomRoomTypeQuery, ApiResult<List<GetBedRoomRoomTypeResponse>>>
    {
        private readonly IBedRoomRoomTypeRoomTypeService _service;
        public GetBedRoomRoomTypeQueryHandler(IBedRoomRoomTypeRoomTypeService service)
        {
            _service = service;
        }
        public async Task<ApiResult<List<GetBedRoomRoomTypeResponse>>> Handle(GetBedRoomRoomTypeQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetBedRoomRoomType();
            return result;
        }
    }
}
