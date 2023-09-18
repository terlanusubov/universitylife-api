using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.UserWishlist.CreateUserWishlist;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.UserWishlist.Commands.CreateUserWishlist
{
    public class CreateUserWishlistCommandHandler : IRequestHandler<CreateUserWishlistCommand, ApiResult<CreateUserWishlistResponse>>
    {
        private readonly IUserWishlistService _wishService;
        public CreateUserWishlistCommandHandler(IUserWishlistService wishService)
        {
            _wishService = wishService;
        }
        public async Task<ApiResult<CreateUserWishlistResponse>> Handle(CreateUserWishlistCommand request, CancellationToken cancellationToken)
        {
            var result = await _wishService.CreateUserWishlist(request.Request);

            return result;
        }
    }
}
