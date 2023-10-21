using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.DeleteBookBedRoomRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.BookBedRoomRoom.Commands.DeleteBookBedRoomRoom
{
    public class DeleteBookBedRoomRoomCommandHandler : IRequestHandler<DeleteBookBedRoomRoomCommand, ApiResult<DeleteBookBedRoomRoomResponse>>
    {
        private readonly IBookBedRoomRoom _bookService;
        public DeleteBookBedRoomRoomCommandHandler(IBookBedRoomRoom bookService)
        {
            _bookService = bookService;
        }
        public async Task<ApiResult<DeleteBookBedRoomRoomResponse>> Handle(DeleteBookBedRoomRoomCommand request, CancellationToken cancellationToken)
        {
            var result = await _bookService.Delete(request.BookId);

            return result;
        }
    }
}
