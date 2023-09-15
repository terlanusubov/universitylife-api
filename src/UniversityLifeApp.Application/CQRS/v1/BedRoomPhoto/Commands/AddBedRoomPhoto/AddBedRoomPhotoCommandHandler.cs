using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomPhoto.AddBedRoomPhoto;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomPhoto.Commands.AddBedRoomPhoto
{
    public class AddBedRoomPhotoCommandHandler : IRequestHandler<AddBedRoomPhotoCommand, ApiResult<AddBedRoomPhotoResponse>>
    {
        private readonly IBedRoomPhotoService _bedRoomPhotoService;

        public AddBedRoomPhotoCommandHandler(IBedRoomPhotoService bedRoomPhotoService)
        {
            _bedRoomPhotoService = bedRoomPhotoService;
        }
        public Task<ApiResult<AddBedRoomPhotoResponse>> Handle(AddBedRoomPhotoCommand request, CancellationToken cancellationToken)
        {
            var result = _bedRoomPhotoService.AddBedroomPhoto(request);
            return result;
        }
    }
}
