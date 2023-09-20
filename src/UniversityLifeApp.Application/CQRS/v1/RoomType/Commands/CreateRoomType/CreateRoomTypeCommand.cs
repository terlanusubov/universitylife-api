using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.RoomType.CreateRoomType;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.RoomType.Commands.CreateRoomType
{
    public class CreateRoomTypeCommand:IRequest<ApiResult<CreateRoomTypeResponse>>
    {
        public CreateRoomTypeCommand(CreateRoomTypeRequest request)
        {
            request = request;
        }
        public CreateRoomTypeRequest Request { get; set; }
    }
}
