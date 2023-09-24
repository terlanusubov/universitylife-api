using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.DeleteBookBedRoomRoom;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.BookBedRoomRoom.Commands.DeleteBookBedRoomRoom
{
    public class DeleteBookBedRoomRoomCommand:IRequest<ApiResult<DeleteBookBedRoomRoomResponse>>
    {
        public DeleteBookBedRoomRoomCommand(int bookId)
        {
            BookId = bookId;
        }

        public int BookId { get; set; }
    }
}
