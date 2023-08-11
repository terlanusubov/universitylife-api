using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomPhoto.AddBedRoomPhoto;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomPhoto.Commands.AddBedRoomPhoto
{
    public class AddBedRoomPhotoCommand : IRequest<ApiResult<AddBedRoomPhotoResponse>>
    {
        public AddBedRoomPhotoCommand(AddBedRoomPhotoRequest request)
        {
            Request = request;
        }
        public AddBedRoomPhotoRequest Request { get; set; }
    }
}
