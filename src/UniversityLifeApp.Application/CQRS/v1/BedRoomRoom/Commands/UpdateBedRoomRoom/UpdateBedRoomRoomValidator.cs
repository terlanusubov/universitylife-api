using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Commands.UpdateBedRoomRoom
{
    public class UpdateBedRoomRoomValidator:AbstractValidator<UpdateBedRoomRoomCommand>
    {
        public UpdateBedRoomRoomValidator()
        {
            RuleFor(x => x.Request.Name)
                .NotEmpty().WithMessage("The Name field cannot be empty.")
                //.MinimumLength(3).WithMessage("The name must contain at least 3 letters.")
                .MaximumLength(30).WithMessage("The name can contain up to 30 characters.");

            RuleFor(x => x.Request.Description)
                .NotEmpty().WithMessage("The description field cannot be empty.")
                //.MinimumLength(10).WithMessage("The name must contain at least 10 letters.")
                .MaximumLength(500).WithMessage("The name can contain up to 500 characters.");

            RuleFor(x => x.Request.Price)
                .NotNull().WithMessage("The price field cannot be empty.")
                .GreaterThanOrEqualTo(1).WithMessage("Price cannot be less than £1.");

            RuleFor(x => x.Request.BedRoomId).NotNull();
            RuleFor(x => x.Request.BedRoomRoomTypeId).NotNull();
        }
    }
}
