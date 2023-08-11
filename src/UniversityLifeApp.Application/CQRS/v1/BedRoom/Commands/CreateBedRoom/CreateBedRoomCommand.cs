using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoom.CreateBedRoom;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoom.Commands.CreateBedRoom
{
    public class CreateBedRoomCommand : IRequest<ApiResult<CreateBedRoomResponse>>
    {
        public CreateBedRoomCommand(CreateBedRoomRequest request)
        {
            Request = request;
        }

        public CreateBedRoomRequest Request { get; set; }
    }
}
