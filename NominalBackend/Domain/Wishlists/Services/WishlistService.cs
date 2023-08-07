﻿using NominalBackend.Domain.Wishlists.Models;
using NominalBackend.Domain.Wishlists.Repositories;
using NominalBackend.Generics;
using NominalBackend.UnitOfWork;

namespace NominalBackend.Domain.Wishlists.Services
{
    public interface IWishlistService : ICrudService<Wishlist>
    {
        Task<List<int>> GetAllWishlistForUser(string userId);
        Task<Wishlist> GetWishlistByItemId(int itemId);
    }
    public class WishlistService : CrudService<Wishlist>, IWishlistService
    {
        private readonly IWishlistRepository _wishlistRepository;

        public WishlistService(IUnitOfWork unitOfWork, ICrudRepository<Wishlist> repository,
            IWishlistRepository wishlistRepository) : base(unitOfWork, repository)
        {
            _wishlistRepository = wishlistRepository;
        }

        public async Task<List<int>> GetAllWishlistForUser(string userId)
        {
            var wishlistIds = await _wishlistRepository.GetAllWishlistForUser(userId);
            return wishlistIds;
        }

        public async Task<Wishlist> GetWishlistByItemId(int itemId)
        {
            var wishlist = await _wishlistRepository.GetWishlistByItemId(itemId);
            return wishlist;
        }
    }
}
