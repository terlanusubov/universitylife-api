using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.GetBookBedRoomRoomById;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.BookBedRoomRoom.Queries.GetBookBedRoomRoomById
{
    public class GetBookBedRoomRoomByIdQueryHandler : IRequestHandler<GetBookBedRoomRoomByIdQuery, ApiResult<GetBookBedRoomRoomByIdResponse>>
    {
        private readonly IBookBedRoomRoom _bookService;
        public GetBookBedRoomRoomByIdQueryHandler(IBookBedRoomRoom bookService)
        {
            _bookService = bookService;
        }
        public async Task<ApiResult<GetBookBedRoomRoomByIdResponse>> Handle(GetBookBedRoomRoomByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _bookService.GetById(request.Id);

            return result;
        }
    }
}
