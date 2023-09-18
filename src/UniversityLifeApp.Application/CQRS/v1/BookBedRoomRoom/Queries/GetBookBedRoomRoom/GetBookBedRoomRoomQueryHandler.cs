using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.GetBookBedRoomRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.BookBedRoomRoom.Queries.GetBookBedRoomRoom
{
    public class GetBookBedRoomRoomQueryHandler : IRequestHandler<GetBookBedRoomRoomQuery, ApiResult<List<GetBookBedRoomRoomResponse>>>
    {
        private readonly IBookBedRoomRoom _bookService;
        public GetBookBedRoomRoomQueryHandler(IBookBedRoomRoom bookService)
        {
            _bookService = bookService;
        }
        public async Task<ApiResult<List<GetBookBedRoomRoomResponse>>> Handle(GetBookBedRoomRoomQuery request, CancellationToken cancellationToken)
        {
            var result = await _bookService.GetBookBedRoomRoom();

            return result;
        }
    }
}
