using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.UserWishlist.CreateUserWishlist;
using UniveristyLifeApp.Models.v1.UserWishlist.DeleteUserWishlist;
using UniveristyLifeApp.Models.v1.UserWishlist.GetUserWishlist;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.UserWishlist.Commands.CreateUserWishlist;
using UniversityLifeApp.Application.CQRS.v1.UserWishlist.Commands.DeleteUserWishlist;
using UniversityLifeApp.Application.CQRS.v1.UserWishlist.Queries.GetUserWishlist;

namespace UniversityLifeApp.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/userwishlist")]
    [ApiVersion("1.0")]
    public class UserWishlistController : BaseController
    {
        private readonly IMediator _mediator;
        public UserWishlistController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<ActionResult<ApiResult<CreateUserWishlistResponse>>> Create(CreateUserWishlistRequest request)
            => await _mediator.Send(new CreateUserWishlistCommand(request));

        [HttpGet]
        public async Task<ActionResult<List<GetUserWishlistResponse>>> GetUserWishlist([FromQuery]GetUserWishlistRequest request)
            => (await _mediator.Send(new GetUserWishlistQuery(request))).Response;

        [HttpDelete("{wishId}")]
        public async Task<ActionResult<ApiResult<DeleteUserWishlistResponse>>> Delete(int wishId)
            => await _mediator.Send(new DeleteUserWishlistCommand(wishId));

    }
}
