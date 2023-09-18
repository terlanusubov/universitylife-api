using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.RejectBook;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.BookBedRoomRoom.Commands.RejectBook
{
    public class RejectBookCommand:IRequest<ApiResult<RejectBookResponse>>
    {
        public RejectBookCommand(int applyId)
        {
            Id = applyId;
        }

        public int Id { get; set; }
    }
}
