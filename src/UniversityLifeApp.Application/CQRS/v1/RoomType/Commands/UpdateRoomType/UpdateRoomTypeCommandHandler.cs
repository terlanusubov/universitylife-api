using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.RoomType.UpdateRoomType;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.RoomType.Commands.UpdateRoomType
{
    public class UpdateRoomTypeCommandHandler : IRequestHandler<UpdateRoomTypeCommand, ApiResult<UpdateRoomTypeResponse>>
    {
        private readonly IRoomTypeService _typeService;
        public UpdateRoomTypeCommandHandler(IRoomTypeService typeService)
        {
            _typeService = typeService;
        }
        public async Task<ApiResult<UpdateRoomTypeResponse>> Handle(UpdateRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var result = await _typeService.Update(request.Request);

            return result;
        }
    }
}
