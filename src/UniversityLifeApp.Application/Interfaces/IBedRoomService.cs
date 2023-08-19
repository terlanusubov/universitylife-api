using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoom.CreateBedRoom;
using UniveristyLifeApp.Models.v1.BedRoom.DeleteBedRoom;
using UniveristyLifeApp.Models.v1.BedRoom.GetBedRoom;
using UniveristyLifeApp.Models.v1.BedRoom.GetBedRoomById;
using UniveristyLifeApp.Models.v1.BedRoom.UpdateBedRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.BedRoom.Commands.CreateBedRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoom.Commands.UpdateBedRoom;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface IBedRoomService
    {
        Task<ApiResult<List<GetBedRoomResponse>>> GetBedRoom(int? cityId);
        Task<ApiResult<GetBedRoomByIdResponse>> GetBedRoomById(int bedroomId);
        Task<ApiResult<CreateBedRoomResponse>> CreateBedRoom(CreateBedRoomCommand createBedRoom);
        Task<ApiResult<UpdateBedRoomResponse>> UpdateBedRoom(UpdateBedRoomCommand updateBedRoom , int bedroomId);
        Task<ApiResult<DeleteBedRoomResponse>> DeleteBedRoom(int bedroomId);
    }
}
