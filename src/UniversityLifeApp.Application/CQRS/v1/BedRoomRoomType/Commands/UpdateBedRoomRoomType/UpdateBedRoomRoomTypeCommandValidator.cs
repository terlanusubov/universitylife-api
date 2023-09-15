using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Commands.UpdateBedRoomRoomType
{
    public class UpdateBedRoomRoomTypeCommandValidator : AbstractValidator<UpdateBedRoomRoomTypeCommand>
    {
        public UpdateBedRoomRoomTypeCommandValidator()
        {
            RuleFor(x => x.RoomTypeId)
                .NotNull().WithMessage("The Id field cannot be empty");
        }
    }
}
