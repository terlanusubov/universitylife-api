using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoom.CreateBedRoom;
using UniveristyLifeApp.Models.v1.BedRoom.GetBedRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.BedRoom.Commands.CreateBedRoom;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface IBedRoomService
    {
        Task<ApiResult<List<GetBedRoomResponse>>> GetBedRoom();
        Task<ApiResult<CreateBedRoomResponse>> CreateBedRoom(CreateBedRoomCommand createBedRoom); 
    }
}
