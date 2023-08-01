using Microsoft.AspNetCore.Mvc;
using NominalBackend.Domain.Items.Models;
using NominalBackend.Domain.Users.Models;
using NominalBackend.Domain.Wishlists.Models;
using NominalBackend.Domain.Wishlists.Services;
using NominalBackend.Helpers.Enums;

namespace NominalBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WishlistController : Controller
    {
        private readonly IWishlistService _wishlistService;

        public WishlistController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        [HttpGet]
        [Route("GetWishlist/{id}", Name = "GetWishlist/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var wishlist = await _wishlistService.GetByIdAsync(id);
            if (wishlist == null) { return NotFound(); }
            return Ok(new
            {
                wishlist
            });
        }


        [HttpGet]
        [Route("GetAllGetWishlists", Name = "GetAllGetWishlists")]
        public async Task<IActionResult> GetAll()
        {
            var wishlists = await _wishlistService.GetAllAsync();
            if (!wishlists.Any()) { return NotFound(); }
            return Ok(new
            {
                wishlists
            });
        }

        [HttpPost]
        [Route("CreateWishlist", Name = "CreateWishlist")]
        public async Task<IActionResult> Create(Wishlist wishlist)
        {
            await _wishlistService.AddAsync(wishlist);
            return Ok(new
            {
                wishlist
            });
        }

        [HttpPut]
        [Route("UpdateWishlist", Name = "UpdateWishlist")]
        public async Task<IActionResult> Update(Wishlist wishlist)
        {
            await _wishlistService.UpdateAsync(wishlist);
            return Ok(new
            {
                wishlist
            });
        }

        [HttpDelete]
        [Route("DeleteWishlist", Name = "DeleteWishlist")]
        public async Task<IActionResult> Delete(Wishlist wishlist)
        {
            await _wishlistService.DeleteAsync(wishlist);
            return Ok(new
            {
                wishlist
            });
        }

        [HttpDelete]
        [Route("SoftDeleteWishlist", Name = "SoftDeleteWishlist")]
        public async Task<IActionResult> SoftDelete(User user,Wishlist wishlist)
        {
            if(user.Id != wishlist.UserId)
            {
                return Unauthorized("Not allowed");
            }
            wishlist.State = State.SoftDeleted;
            await _wishlistService.UpdateAsync(wishlist);
            return Ok(new
            {
                wishlist.Id
            });
        }
    }
}
