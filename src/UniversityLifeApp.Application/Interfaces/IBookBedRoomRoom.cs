using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.CreateBookBedRoomRoom;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface IBookBedRoomRoom
    {
        Task<ApiResult<CreateBookBedRoomRoomResponse>> BookBedRoomRoom(int userId, int bedRoomRoomId);
    }
}
