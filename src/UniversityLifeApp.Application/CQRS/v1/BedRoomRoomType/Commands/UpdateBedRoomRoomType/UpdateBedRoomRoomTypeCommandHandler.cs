using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.UpdateBedRoomRoomType;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Commands.UpdateBedRoomRoomType
{
    public class UpdateBedRoomRoomTypeCommandHandler : IRequestHandler<UpdateBedRoomRoomTypeCommand, ApiResult<UpdateBedRoomRoomTypeResponse>>
    {
        private readonly IBedRoomRoomTypeRoomTypeService _service;
        public UpdateBedRoomRoomTypeCommandHandler(IBedRoomRoomTypeRoomTypeService service)
        {
             
            _service = service;
        }
        public async Task<ApiResult<UpdateBedRoomRoomTypeResponse>> Handle(UpdateBedRoomRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.UpdateBedRoomRoomType(request, request.RoomTypeId);
            return result;

        }
    }
}
