using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.AcceptBook;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.CreateBookBedRoomRoom;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.GetBookBedRoomRoom;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.RejectBook;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.BookBedRoomRoom.Commands.CreateBookBedRoomRoom;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface IBookBedRoomRoom
    {
        Task<ApiResult<CreateBookBedRoomRoomResponse>> BookBedRoomRoom(CreateBookBedRoomRoomCommand request);
        Task<ApiResult<List<GetBookBedRoomRoomResponse>>> GetBookBedRoomRoom(GetBookBedRoomRoomRequest request);
        Task<ApiResult<AcceptBookResponse>> Accept(int id);
        Task<ApiResult<RejectBookResponse>> Reject(int id);
    }
}
