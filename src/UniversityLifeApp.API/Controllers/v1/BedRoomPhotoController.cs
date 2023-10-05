using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.Countries.AddCountry;
using UniversityLifeApp.Application.CQRS.v1.Countryies.Commands.AddCountry;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;
using UniveristyLifeApp.Models.v1.BedRoomPhoto.AddBedRoomPhoto;
using UniversityLifeApp.Application.CQRS.v1.BedRoomPhoto.Commands.AddBedRoomPhoto;

namespace UniversityLifeApp.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/BedRoomPhoto")]
    [ApiVersion("1.0")]
    public class BedRoomPhotoController : BaseController
    {
        private readonly IMediator _mediator;
        public BedRoomPhotoController(IMediator mediator, IFileService fileService)
        {
             _mediator = mediator;
        }
            
        [HttpPost]
        public async Task<ApiResult<AddBedRoomPhotoResponse>> AddBedRoomPhoto([FromForm]AddBedRoomPhotoRequest request)
           => await _mediator.Send(new AddBedRoomPhotoCommand(request));



        //[HttpPost]
        //public async Task<ApiResult<AddBedRoomPhotoResponse>> AddBedRoomPhoto([FromForm]AddBedRoomPhotoRequest request)
        //   => await _mediator.Send(new AddBedRoomPhotoCommand(request));

    }
}
