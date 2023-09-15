using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.UserWishlist.DeleteUserWishlist;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.UserWishlist.Commands.DeleteUserWishlist
{
    public class DeleteUserWishlistCommand:IRequest<ApiResult<DeleteUserWishlistResponse>>
    {
        public DeleteUserWishlistCommand(int wishId)
        {
            WishId = wishId;  
        }
        public int WishId { get; set; }
    }
}
