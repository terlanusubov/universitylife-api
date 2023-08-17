using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.UserWishlist.GetUserWishlist;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class UserWishlistService : IUserWishlistService
    {
        private readonly ApplicationContext _context;
        public UserWishlistService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<List<GetUserWishlistResponse>>> GetUserWishlist(int userId)
        {
            var Wishlist = await _context.UserWishlists.Where(x=>x.UserId == userId).Select(x=> new GetUserWishlistResponse
            {
                UserId = x.Id,
                BedRoomId = x.BedRoomId,

            }).ToListAsync();

            return ApiResult<List<GetUserWishlistResponse>>.OK(Wishlist);        }
    }
}
