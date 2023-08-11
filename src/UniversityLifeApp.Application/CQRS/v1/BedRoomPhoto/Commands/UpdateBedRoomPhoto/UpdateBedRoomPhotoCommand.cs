using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomPhoto.UpdateBedRoomPhoto;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomPhoto.Commands.UpdateBedRoomPhoto
{
    public class UpdateBedRoomPhotoCommand : IRequest<ApiResult<UpdateBedRoomPhotoResponse>>
    {
        public UpdateBedRoomPhotoCommand(UpdateBedRoomPhotoRequest bedroomPhotoRequest, int bedRoomPhotoId)
        {
            BedRoomPhotoRequest = bedroomPhotoRequest;
            BedroomPhotoId= bedRoomPhotoId;
        }
        public UpdateBedRoomPhotoRequest BedRoomPhotoRequest { get; set; }
        public int BedroomPhotoId { get; set; }
    }
}
