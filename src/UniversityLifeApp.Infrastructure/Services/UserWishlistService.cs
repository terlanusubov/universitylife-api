using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.UserWishlist.CreateUserWishlist;
using UniveristyLifeApp.Models.v1.UserWishlist.DeleteUserWishlist;
using UniveristyLifeApp.Models.v1.UserWishlist.GetUserWishlist;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.UserWishlist.Queries.GetUserWishlist;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Domain.Entities;
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

        public async Task<ApiResult<CreateUserWishlistResponse>> CreateUserWishlist(CreateUserWishlistRequest request)
        {
            UserWishlist wish = new UserWishlist
            {
                UserId = request.UserId,
                BedRoomId = request.BedRoomId,
            };

            await _context.UserWishlists.AddAsync(wish);
            await _context.SaveChangesAsync();

            var response = new CreateUserWishlistResponse
            {
                UserId = wish.UserId,
                BedRoomId = wish.BedRoomId,
                UserWishlistId = wish.Id,
            };

            return ApiResult<CreateUserWishlistResponse>.OK(response);
        }

        public async Task<ApiResult<DeleteUserWishlistResponse>> Delete(int wishId)
        {
            var wish = await _context.UserWishlists.Where(x => x.Id == wishId).FirstOrDefaultAsync();

            if (wish != null)
            {
                _context.UserWishlists.Remove(wish);
                await _context.SaveChangesAsync();
            }

            DeleteUserWishlistResponse response = new DeleteUserWishlistResponse
            {
                UserId = wish.UserId,
                BedRoomId = wish.BedRoomId,
                UserWishlistId = wish.Id,
            };

            return ApiResult<DeleteUserWishlistResponse>.OK(response);
        }

        public async Task<ApiResult<List<GetUserWishlistResponse>>> GetUserWishlist(GetUserWishlistRequest request)
        {
            var Wishlist = await _context.UserWishlists.Where(x=>x.UserId == request.UserId).Select(x=> new GetUserWishlistResponse
            {
                UserId = x.UserId,
                BedRoomId = x.BedRoomId,
                UserWishlistId = x.Id

            }).ToListAsync();

            return ApiResult<List<GetUserWishlistResponse>>.OK(Wishlist);        }
    }
}
