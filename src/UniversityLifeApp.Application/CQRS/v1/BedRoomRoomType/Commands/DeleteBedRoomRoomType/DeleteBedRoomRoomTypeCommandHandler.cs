using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.DeleteBedRoomRoomType;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Commands.DeleteBedRoomRoomType
{
    public class DeleteBedRoomRoomTypeCommandHandler : IRequestHandler<DeleteBedRoomRoomTypeCommand, ApiResult<DeleteBedRoomRoomTypeResponse>>
    {
        private readonly IBedRoomRoomTypeRoomTypeService _service;
        public DeleteBedRoomRoomTypeCommandHandler(IBedRoomRoomTypeRoomTypeService service)
            => _service = service;

        public async Task<ApiResult<DeleteBedRoomRoomTypeResponse>> Handle(DeleteBedRoomRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.DeleteBedRoomRoomType(request.BedRoomRoomTypeId);
            return result;
        }
    }
}
