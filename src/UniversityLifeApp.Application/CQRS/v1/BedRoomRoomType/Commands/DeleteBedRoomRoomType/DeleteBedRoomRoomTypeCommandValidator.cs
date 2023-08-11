﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Commands.DeleteBedRoomRoomType
{
    public class DeleteBedRoomRoomTypeCommandValidator : AbstractValidator<DeleteBedRoomRoomTypeCommand>
    {
        public DeleteBedRoomRoomTypeCommandValidator()
        {
            RuleFor(x => x.BedRoomRoomTypeId)
                .NotNull().WithMessage("The Id field cannot be empty");
        }
    }
}
