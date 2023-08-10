﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomPhoto.AddBedRoomPhoto;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.BedRoomPhoto.Commands.AddBedRoomPhoto;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface IBedRoomPhotoService
    {
        Task<ApiResult<AddBedRoomPhotoResponse>> AddBedroomPhoto(AddBedRoomPhotoCommand addBedRoom);
    }
}
