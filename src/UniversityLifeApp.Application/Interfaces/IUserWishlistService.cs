using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.UserWishlist.GetUserWishlist;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface IUserWishlistService
    {
        Task<ApiResult<List<GetUserWishlistResponse>>> GetUserWishlist(int userId);
    }
}
