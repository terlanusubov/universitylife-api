using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.CloseBedRoom.GetCloseBedRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.CloseBedRoom.Queries.GetCloseBedroom
{
    public class GetCloseBedRoomQueryHandler : IRequestHandler<GetCloseBedRoomQuery, ApiResult<GetCloseBedRoomResponse>>
    {
        private readonly IGetCloseBedroom _getCloseBedroom;

        public GetCloseBedRoomQueryHandler(IGetCloseBedroom getCloseBedroom)
        {
            _getCloseBedroom = getCloseBedroom;
        }

        public Task<ApiResult<GetCloseBedRoomResponse>> Handle(GetCloseBedRoomQuery request, CancellationToken cancellationToken)
        {
            var result = _getCloseBedroom.GetCloseBedroom(request.UniversityId);
            return result;
        }
    }
}