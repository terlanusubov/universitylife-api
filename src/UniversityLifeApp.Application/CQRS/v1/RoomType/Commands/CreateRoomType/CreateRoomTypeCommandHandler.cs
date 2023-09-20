using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.RoomType.CreateRoomType;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.RoomType.Commands.CreateRoomType
{
    public class CreateRoomTypeCommandHandler : IRequestHandler<CreateRoomTypeCommand, ApiResult<CreateRoomTypeResponse>>
    {
        private readonly IRoomTypeService _typeService;
        public CreateRoomTypeCommandHandler(IRoomTypeService typeService)
        {
            _typeService = typeService;
        }
        public async Task<ApiResult<CreateRoomTypeResponse>> Handle(CreateRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var result = await _typeService.Create(request.Request);

            return result;
        }
    }
}
