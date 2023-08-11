using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoom.Commands.DeleteBedRoom
{
    public class DeleteBedRoomCommandValidator : AbstractValidator<DeleteBedRoomCommand>
    {
        public DeleteBedRoomCommandValidator()
        {
            RuleFor(x=>x.BedRoomId)
                .NotNull().WithMessage("The Id field cannot be empty");
        }
    }
}
