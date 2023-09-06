using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoom.UpdateBedRoomRoom;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Commands.UpdateBedRoomRoom
{
    public class UpdateBedRoomRoomCommand:IRequest<ApiResult<UpdateBedRoomRoomResponse>>
    {
        public UpdateBedRoomRoomCommand(UpdateBedRoomRoomRequest request, int bedRoomRoomId)
        {
            Request = request;
            BedRoomRoomId = bedRoomRoomId;
        }
        public int BedRoomRoomId { get; set; }
        public UpdateBedRoomRoomRequest Request { get; set; }
    }
}
