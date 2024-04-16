using AutoMapper;
using BrainboxApi.Data;
using BrainboxApi.DTOs.Carts;
using BrainboxApi.Entity;
using BrainboxApi.Helpers;
using BrainboxApi.Repository.IRepository;
using BrainboxApi.Services.Interface;

namespace BrainboxApi.Services.Implementation
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<APIResponse> CreateCart(CreateCartDto cart)
        {
            var newCart = _mapper.Map<Cart>(cart);
            var result = await _cartRepository.CreateCart(newCart);
            if (result > 0)
                return APIResponse.GetSuccessMessage(System.Net.HttpStatusCode.Created, newCart, MessageConstants.CreateSuccessMessage);
            else
                return APIResponse.GetFailureMessage(System.Net.HttpStatusCode.InternalServerError, null, MessageConstants.CreateFailureMessage);
        }

        public async Task<APIResponse> UpdateCart(UpdateCartDto cart)
        {
            var newCart = _mapper.Map<Cart>(cart);
            var result = await _cartRepository.UpdateCart(newCart);
            if (result > 0)
                return APIResponse.GetSuccessMessage(System.Net.HttpStatusCode.OK, newCart, MessageConstants.UpdateSuccessMessage);
            else
                return APIResponse.GetFailureMessage(System.Net.HttpStatusCode.InternalServerError, null, MessageConstants.UpdateFailureMessage);
        }

        public async Task<APIResponse> DeleteCart(int cartId)
        {
            var result = await _cartRepository.DeleteCart(cartId);
            if (result > 0)
                return APIResponse.GetSuccessMessage(System.Net.HttpStatusCode.OK, null, MessageConstants.DeleteSuceessMessage);
            else
                return APIResponse.GetFailureMessage(System.Net.HttpStatusCode.InternalServerError, null, MessageConstants.DeleteFailureMessage);
        }

        public async Task<APIResponse> DeleteCartByUserId(int userId)
        {
            var result = await _cartRepository.DeleteCartByUserId(userId);
            if (result > 0)
                return APIResponse.GetSuccessMessage(System.Net.HttpStatusCode.OK, null, MessageConstants.DeleteSuceessMessage);
            else
                return APIResponse.GetFailureMessage(System.Net.HttpStatusCode.InternalServerError, null, MessageConstants.DeleteFailureMessage);
        }

        public async Task<APIResponse> GetCartByUserId(int userId)
        {
            var cart = await _cartRepository.GetCartByUserId(userId);
            if (cart != null)
                return APIResponse.GetSuccessMessage(System.Net.HttpStatusCode.OK, cart, MessageConstants.FetchSuccessMessage);
            else
                return APIResponse.GetFailureMessage(System.Net.HttpStatusCode.NotFound, null, MessageConstants.NotFoundMessage);
        }

        public async Task<APIResponse> AddToCart(AddToCartDto addToCartDto)
        {  
            var cart = await _cartRepository.AddToCart(addToCartDto.ProductId, addToCartDto.Quantity, addToCartDto.UserId);
            if (cart != null)
                return APIResponse.GetSuccessMessage(System.Net.HttpStatusCode.OK, cart, MessageConstants.FetchSuccessMessage);
            else
                return APIResponse.GetFailureMessage(System.Net.HttpStatusCode.NotFound, null, MessageConstants.NotFoundMessage);
        }
    }
}
