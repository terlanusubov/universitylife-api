using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.AcceptBook;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.BookBedRoomRoom.Commands.AcceptBook
{
    public class AcceptBookCommand:IRequest<ApiResult<AcceptBookResponse>>
    {
        public AcceptBookCommand(int applyId)
        {
            Id = applyId;
        }

        public int Id { get; set; }

    }
}
