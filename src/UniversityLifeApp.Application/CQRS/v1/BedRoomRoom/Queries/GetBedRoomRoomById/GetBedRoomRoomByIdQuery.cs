using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoom.GetBedRoomRoom;
using UniveristyLifeApp.Models.v1.BedRoomRoom.GetBedRoomRoomById;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Queries.GetBedRoomRoomById
{
    public class GetBedRoomRoomByIdQuery:IRequest<ApiResult<GetBedRoomRoomByIdResponse>>
    {
        public GetBedRoomRoomByIdQuery(int bedRoomRoomId)
        {
            BedRoomRoomId = bedRoomRoomId;
        }

        public int BedRoomRoomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        //Bedroom
        public int BedRoomId { get; set; }

        //Bedroomroom type
        public int BedRoomRoomTypeId { get; set; }
    }
}
