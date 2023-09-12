using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.UserWishlist.GetUserWishlist;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.UserWishlist.Queries.GetUserWishlist
{
    public class GetUserWishlistQuery : IRequest<ApiResult<List<GetUserWishlistResponse>>>
    {
        public GetUserWishlistQuery(GetUserWishlistRequest request)
        {
            Request = request;
        }
        public GetUserWishlistRequest Request { get; set; }
        public int BedRoomId { get; set; }
    }
}
