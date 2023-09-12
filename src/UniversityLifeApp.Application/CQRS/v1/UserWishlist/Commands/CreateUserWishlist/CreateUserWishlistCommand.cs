using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.UserWishlist.CreateUserWishlist;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.UserWishlist.Commands.CreateUserWishlist
{
    public class CreateUserWishlistCommand:IRequest<ApiResult<CreateUserWishlistResponse>>
    {
        public CreateUserWishlistCommand(CreateUserWishlistRequest request)
        {
            Request = request;
        }
        public CreateUserWishlistRequest Request { get; set; }
    }
}
