using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.CreateBookBedRoomRoom;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.GetBookBedRoomRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.BookBedRoomRoom.Commands.CreateBookBedRoomRoom;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface IBookBedRoomRoom
    {
        Task<ApiResult<CreateBookBedRoomRoomResponse>> BookBedRoomRoom(CreateBookBedRoomRoomCommand request);
        Task<ApiResult<List<GetBookBedRoomRoomResponse>>> GetBookBedRoomRoom(); 
    }
}
