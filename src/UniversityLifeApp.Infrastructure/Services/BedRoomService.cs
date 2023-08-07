using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoom.CreateBedRoom;
using UniveristyLifeApp.Models.v1.BedRoom.GetBedRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.BedRoom.Commands.CreateBedRoom;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class BedRoomService : IBedRoomService
    {
        public Task<ApiResult<CreateBedRoomResponse>> CreateBedRoom(CreateBedRoomCommand createBedRoom)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<List<GetBedRoomResponse>>> GetBedRoom()
        {
            throw new NotImplementedException();
        }
    }
}
