using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoom.Commands.CreateBedRoom
{
    public class CreateBedRoomCommandValidator : AbstractValidator<CreateBedRoomCommand>
    {
        public CreateBedRoomCommandValidator()
        {
            RuleFor(x => x.Request.Name)
                .NotNull().WithMessage("The Name field cannot be empty")
                .MinimumLength(3).WithMessage("The name must contain at least 3 letters.")
                .MaximumLength(50).WithMessage("The name can contain up to 30 characters.");

            RuleFor(x => x.Request.Longitude)
                .NotNull().WithMessage("The Longitude field cannot be empty");

            RuleFor(x => x.Request.Latitude)
                .NotNull().WithMessage("The Latitude field cannot be empty");

            RuleFor(x => x.Request.DistanceToCenter)
                .NotNull().WithMessage("The DistanceToCenter field cannot be empty");

            RuleFor(x => x.Request.Description)
                .NotNull().WithMessage("The description field cannot be empty.")
                .MinimumLength(10).WithMessage("The name must contain at least 10 letters.")
                .MaximumLength(500).WithMessage("The name can contain up to 500 characters.");

            RuleFor(x => x.Request.Rating)
                .NotNull().WithMessage("The Rating field cannot be empty");

            RuleFor(x => x.Request.CityId)
                .NotNull().WithMessage("The DistanceToCenter field cannot be empty");






        }
    }
}
