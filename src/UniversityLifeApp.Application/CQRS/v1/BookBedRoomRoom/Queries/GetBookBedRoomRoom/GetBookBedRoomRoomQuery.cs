using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.GetBookBedRoomRoom;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.BookBedRoomRoom.Queries.GetBookBedRoomRoom
{
    public class GetBookBedRoomRoomQuery : IRequest<ApiResult<List<GetBookBedRoomRoomResponse>>>
    {
        public int Id { get; set; }
        public string BedRoomRoomName { get; set; }
        public string Fullname { get; set; }
        public float Price { get; set; }

    }
}
