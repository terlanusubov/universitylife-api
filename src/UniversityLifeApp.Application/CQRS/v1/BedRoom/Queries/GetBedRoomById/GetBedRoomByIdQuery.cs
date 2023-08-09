using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoom.GetBedRoomById;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoom.Queries.GetBedRoomById
{
    public class GetBedRoomByIdQuery : IRequest<ApiResult<GetBedRoomByIdResponse>>
    {
        public GetBedRoomByIdQuery(int bedroomId)
        {
            BedRoomId = bedroomId;
        }
        public int BedRoomId { get; set; }
        public int BedRoomStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Rating { get; set; }
        public float DistanceToCenter { get; set; }

        //City
        public int CityId { get; set; }
    }
}
