using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Commands.CreateBedRoomRoomType
{
    public class CreateBedRoomRoomTypeCommandValidator : AbstractValidator<CreateBedRoomRoomTypeCommand>
    {
        public CreateBedRoomRoomTypeCommandValidator()
        {
            RuleFor(x=>x.Request.Name)
                .NotEmpty().WithMessage("The Name field cannot be empty.")
                .MaximumLength(20).WithMessage("The name can contain up to 20 characters.")
                .MinimumLength(3).WithMessage("The name must contain at least 3 letters.");

            //RuleFor(x => x.Request.BedRoomId)
            //    .NotEmpty().WithMessage("The BedRoom field cannot be empty.");



        }
    }
}
