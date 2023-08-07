using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NominalBackend.Domain.ApplicationUser.Models;
using NominalBackend.Domain.Images.Services;
using NominalBackend.Domain.Items.Models;
using NominalBackend.Domain.Items.Services;
using NominalBackend.Domain.Users.Models;
using NominalBackend.Domain.Wishlists.Models;
using NominalBackend.Domain.Wishlists.Services;
using NominalBackend.Helpers.Enums;
using System.Security.Claims;

namespace NominalBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WishlistController : Controller
    {
        private readonly IWishlistService _wishlistService;
        private readonly IItemService _itemService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IImageService _imageService;

        public WishlistController(IWishlistService wishlistService, IItemService itemService,
            UserManager<IdentityUser> userManager, IImageService imageService)
        {
            _wishlistService = wishlistService;
            _itemService = itemService;
            _userManager = userManager;
            _imageService = imageService;
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


        //TODO RETURN WISHLISTID
        //TODO CHECK WISHLIST STATE AND EXISTENCE
        [Authorize(Roles = "Client")]
        [HttpGet]
        [Route("GetUserWishlist", Name = "GetUserWishlist")]
        public async Task<IActionResult> GetUserWishlist([FromQuery] int skip = 0,[FromQuery] int size = 9)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var wishlistsIds = await _wishlistService.GetAllWishlistForUser(userId);
            if(wishlistsIds == null || wishlistsIds.Count == 0)
            {
                return NotFound("There is no Wishlisted items yet");
            }
            var items = await _itemService.GetItemsByIds(wishlistsIds, skip, size);
            foreach(var item in items)
            {
                var images = await _imageService.GetImagesByItemId(item.Id);
            }
            if(!items.Any() || items == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                items
            });
        }


        [Authorize(Roles = "Client")]
        [HttpPost]
        [Route("AddWishlistItemToUser", Name = "AddWishlistItemToUser")]
        public async Task<IActionResult> AddWishlistToUser(int itemId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var item = await _itemService.GetByIdAsync(itemId);
            if(item == null) { return NotFound("No Item Found"); }

            Wishlist wishlist = new Wishlist()
            {
                ItemId = itemId,
                UserId = userId,
                State = State.Active
            };

            var newWishlist = await _wishlistService.AddAsync(wishlist);
            return Ok(new
            {
                newWishlist.Id
            });
        }


        [Authorize(Roles = "Client")]
        [HttpDelete]
        [Route("SoftDeleteWishlist", Name = "SoftDeleteWishlist")]
        public async Task<IActionResult> SoftDelete(int wishlistId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var wishlist = await _wishlistService.GetByIdAsync(wishlistId);
            if(wishlist == null) { return NotFound(); }
            if(wishlist.UserId != userId)
            {
                return Unauthorized("Not Allowed");
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
