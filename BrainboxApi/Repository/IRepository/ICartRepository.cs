using BrainboxApi.Entity;

namespace BrainboxApi.Repository.IRepository
{
    public interface ICartRepository
    {
        Task<int> CreateCart(Cart cart);
        Task<int> UpdateCart(Cart cart);
        Task<int> DeleteCart(int cartId);
        Task<int> DeleteCartByUserId(int userId);
        Task<Cart> GetCartByUserId(int userId);
        Task<Cart> AddToCart(int productId, int quantity, int cartId);
    }
}
