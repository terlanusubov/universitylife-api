using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.UserWishlist.GetUserWishlist;
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

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<GetUserWishlistResponse>>> GetUserWishlist(int userId)
            => (await _mediator.Send(new GetUserWishlistQuery(userId))).Response;

    }
}
