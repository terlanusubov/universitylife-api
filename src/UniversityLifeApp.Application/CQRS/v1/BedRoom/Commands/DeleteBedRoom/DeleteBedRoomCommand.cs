using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoom.DeleteBedRoom;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoom.Commands.DeleteBedRoom
{
    public class DeleteBedRoomCommand : IRequest<ApiResult<DeleteBedRoomResponse>>
    {
        public DeleteBedRoomCommand(int bedRoomId)
        {
            BedRoomId = bedRoomId;
        }

        public int BedRoomId { get; set; }
    }
}
