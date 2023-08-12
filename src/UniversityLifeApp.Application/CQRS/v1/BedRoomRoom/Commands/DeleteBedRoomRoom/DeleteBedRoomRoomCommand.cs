using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoom.DeleteBedRoomRoom;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Commands.DeleteBedRoomRoom
{
    public class DeleteBedRoomRoomCommand:IRequest<ApiResult<DeleteBedRoomRoomResponse>>
    {
        public DeleteBedRoomRoomCommand(int bedRoomRoomId)
            => BedRoomRoomId = bedRoomRoomId;

        public int BedRoomRoomId { get; set; }
    }
}
