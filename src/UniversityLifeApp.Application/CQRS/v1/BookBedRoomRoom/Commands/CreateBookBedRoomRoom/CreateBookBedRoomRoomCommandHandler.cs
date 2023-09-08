using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.CreateBookBedRoomRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.BookBedRoomRoom.Commands.CreateBookBedRoomRoom
{
    public class CreateBookBedRoomRoomCommandHandler : IRequestHandler<CreateBookBedRoomRoomCommand,ApiResult<CreateBookBedRoomRoomResponse>>
    {
        private readonly IBookBedRoomRoom _bookBedRoomRoom;
        public CreateBookBedRoomRoomCommandHandler(IBookBedRoomRoom bookBedRoomRoom)
        {
            _bookBedRoomRoom = bookBedRoomRoom;
        }
        public async Task<ApiResult<CreateBookBedRoomRoomResponse>> Handle(CreateBookBedRoomRoomCommand request, CancellationToken cancellationToken)
        {
            var result = await _bookBedRoomRoom.BookBedRoomRoom(request);

            return result;
        }
    }
}
