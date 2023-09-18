using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.AcceptBook;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.BookBedRoomRoom.Commands.AcceptBook
{
    public class AcceptBookCommandHandler : IRequestHandler<AcceptBookCommand, ApiResult<AcceptBookResponse>>
    {
        private readonly IBookBedRoomRoom _bookService;
        public AcceptBookCommandHandler(IBookBedRoomRoom bookService)
        {
            _bookService = bookService;
        }
        public async Task<ApiResult<AcceptBookResponse>> Handle(AcceptBookCommand request, CancellationToken cancellationToken)
        {
            var result = await _bookService.Accept(request.Id);

            return result;
        }
    }
}
