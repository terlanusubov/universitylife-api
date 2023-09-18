using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.CreateBedRoomRoomType;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Commands.CreateBedRoomRoomType
{
    public class CreateBedRoomRoomTypeCommandHandler : IRequestHandler<CreateBedRoomRoomTypeCommand, ApiResult<CreateBedRoomRoomTypeResponse>>
    {
        private readonly IBedRoomRoomTypeRoomTypeService _service;
        public CreateBedRoomRoomTypeCommandHandler(IBedRoomRoomTypeRoomTypeService service)
        {
            _service = service;
        }

        public async Task<ApiResult<CreateBedRoomRoomTypeResponse>> Handle(CreateBedRoomRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.CreateBedRoomRoomType(request);
            return result;
        }
    }
}
