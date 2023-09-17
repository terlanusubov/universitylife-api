using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.RejectBook;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.BookBedRoomRoom.Commands.RejectBook
{
    public class RejectBookCommandHandler : IRequestHandler<RejectBookCommand, ApiResult<RejectBookResponse>>
    {
        private readonly IBookBedRoomRoom _bookService;
        public RejectBookCommandHandler(IBookBedRoomRoom bookService)
        {
            _bookService = bookService;
        }
        public async Task<ApiResult<RejectBookResponse>> Handle(RejectBookCommand request, CancellationToken cancellationToken)
        {
            var result = await _bookService.Reject(request.Id);

            return result;
        }
    }
}
