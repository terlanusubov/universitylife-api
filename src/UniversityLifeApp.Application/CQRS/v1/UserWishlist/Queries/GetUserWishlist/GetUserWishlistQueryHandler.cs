using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.UserWishlist.GetUserWishlist;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.UserWishlist.Queries.GetUserWishlist
{
    public class GetUserWishlistQueryHandler : IRequestHandler<GetUserWishlistQuery, ApiResult<List<GetUserWishlistResponse>>>
    {
        private readonly IUserWishlistService _service;
        public GetUserWishlistQueryHandler(IUserWishlistService service)
            => _service = service;
        public async Task<ApiResult<List<GetUserWishlistResponse>>> Handle(GetUserWishlistQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetUserWishlist(request.UserId);
            return result;
        }
    }
}
