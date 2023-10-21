using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.UserWishlist.DeleteUserWishlist;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.UserWishlist.Commands.DeleteUserWishlist
{
    public class DeleteUserWishlistCommandHandler : IRequestHandler<DeleteUserWishlistCommand, ApiResult<DeleteUserWishlistResponse>>
    {
        private readonly IUserWishlistService _wishService;
        public DeleteUserWishlistCommandHandler(IUserWishlistService wishService)
        {
            _wishService = wishService;
        }
        public async Task<ApiResult<DeleteUserWishlistResponse>> Handle(DeleteUserWishlistCommand request, CancellationToken cancellationToken)
        {
            var result = await _wishService.Delete(request.WishId);

            return result;
        }
    }
}
