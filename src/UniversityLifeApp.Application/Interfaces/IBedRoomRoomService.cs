using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoom.CreateCity;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Commands.CreateBedRoomRoom;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface IBedRoomRoomService
    {
        Task<ApiResult<CreateBedRoomRoomResponse>> CreateBedRoomRoom(CreateBedRoomRoomCommand request);
    }
}
