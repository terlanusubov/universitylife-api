using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoom.GetBedRoomRoom;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Queries.GetBedRoomRoom
{
    public class GetBedRoomRoomQuery:IRequest<ApiResult<List<GetBedRoomRoomResponse>>>
    {
        public GetBedRoomRoomQuery(GetBedRoomRoomRequest request)
        {
            Request = request;
        }

        public GetBedRoomRoomRequest Request { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        //Bedroom
        public int BedRoomId { get; set; }

        //Bedroomroom type
        public int BedRoomRoomTypeId { get; set; }
    }
}
