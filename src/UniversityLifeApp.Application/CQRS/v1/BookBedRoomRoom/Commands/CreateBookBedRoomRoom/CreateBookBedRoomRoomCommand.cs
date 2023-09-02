using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.CreateBookBedRoomRoom;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.BookBedRoomRoom.Commands.CreateBookBedRoomRoom
{
    public class CreateBookBedRoomRoomCommand:IRequest<ApiResult<CreateBookBedRoomRoomResponse>>
    {
        public CreateBookBedRoomRoomCommand(int userId, int bedRoomRoomId)
        {
            UserId = userId;
            BedRoomRoomId = bedRoomRoomId;
        }
        public int UserId { get; set; }
        public int BedRoomRoomId { get; set; }
    }
}
