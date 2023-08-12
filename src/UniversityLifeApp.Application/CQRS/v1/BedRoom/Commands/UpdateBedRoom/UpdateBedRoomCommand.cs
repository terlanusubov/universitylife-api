using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoom.UpdateBedRoom;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoom.Commands.UpdateBedRoom
{
    public class UpdateBedRoomCommand : IRequest<ApiResult<UpdateBedRoomResponse>>
    {
        public UpdateBedRoomCommand(UpdateBedRoomRequest request , int bedroomId)
        {

            Request = request;
            BedRoomId = bedroomId;

        }

        public UpdateBedRoomRequest Request { get; set; }

        public int BedRoomId { get; set; }
    }
}
