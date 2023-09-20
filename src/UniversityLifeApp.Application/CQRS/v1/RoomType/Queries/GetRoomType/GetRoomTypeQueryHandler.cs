using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.RoomType.GetRoomType;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.RoomType.Queries.GetRoomType
{
    public class GetRoomTypeQueryHandler : IRequestHandler<GetRoomTypeQuery, ApiResult<List<GetRoomTypeResponse>>>
    {
        private readonly IRoomTypeService _typeService;
        public GetRoomTypeQueryHandler(IRoomTypeService typeService)
        {
            _typeService = typeService;
        }
        public async Task<ApiResult<List<GetRoomTypeResponse>>> Handle(GetRoomTypeQuery request, CancellationToken cancellationToken)
        {
            var result = await _typeService.Get();

            return result;
        }
    }
}
