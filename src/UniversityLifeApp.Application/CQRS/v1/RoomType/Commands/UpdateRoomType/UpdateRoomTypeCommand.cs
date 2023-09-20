using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.RoomType.UpdateRoomType;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.RoomType.Commands.UpdateRoomType
{
    public class UpdateRoomTypeCommand:IRequest<ApiResult<UpdateRoomTypeResponse>>
    {
        public UpdateRoomTypeCommand(UpdateRoomTypeRequest request)
        {
            Request = request;
        }

        public UpdateRoomTypeRequest Request;
    }
}
