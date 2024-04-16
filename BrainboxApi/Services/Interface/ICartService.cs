using BrainboxApi.DTOs.Carts;
using BrainboxApi.Entity;
using BrainboxApi.Helpers;

namespace BrainboxApi.Services.Interface
{
    public interface ICartService
    {
        Task<APIResponse> CreateCart(CreateCartDto cart);
        Task<APIResponse> UpdateCart(UpdateCartDto cart);
        Task<APIResponse> DeleteCart(int cartId);
        Task<APIResponse> DeleteCartByUserId(int userId);
        Task<APIResponse> GetCartByUserId(int userId);
        Task<APIResponse> AddToCart(AddToCartDto model);
    }
}
