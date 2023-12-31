﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.GetBedRoomRoomTypeById;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Queries.GetBedRoomRoomTypeById
{
    public class GetBedRoomRoomTypeByIdQuery : IRequest<ApiResult<GetBedRoomRoomTypeByIdResponse>>
    {
        public GetBedRoomRoomTypeByIdQuery(int roomTypeId)
        {
            RoomTypeId = roomTypeId;
        }

        public int RoomTypeId { get; set; }
    }
}
