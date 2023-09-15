using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoom.GetBedRoom;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoom.Queries.GetBedRoom
{
    public class GetBedRoomQuery : IRequest<ApiResult<GetBedRoomResponse>>
    {
        public GetBedRoomQuery(GetBedRoomRequest request)
        {
            Request = request;
        }

        public GetBedRoomRequest Request { get; set; }
        public int BedRoomStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Rating { get; set; }
        public float DistanceToCenter { get; set; }
        public double Distance { get; set; }
    }
}
