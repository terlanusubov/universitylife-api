using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoom.CreateCity;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Commands.CreateBedRoomRoom
{
    public class CreateBedRoomRoomCommand:IRequest<ApiResult<CreateBedRoomRoomResponse>>
    {
        public CreateBedRoomRoomCommand(CreateBedRoomRoomRequest request)
        {
            Request = request;
        }

        public CreateBedRoomRoomRequest Request { get; set; }
    }
}
