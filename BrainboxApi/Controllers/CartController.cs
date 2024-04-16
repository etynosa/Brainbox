using BrainboxApi.DTOs.Carts;
using BrainboxApi.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrainboxApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        [Route("cart/{userId}")]
        public async Task<IActionResult> GetCartByUserId(int userId)
        {
            var response = await _cartService.GetCartByUserId(userId);
            return Ok(response);
        }

        [HttpPut]
        [Route("cart/add")]
        public async Task<IActionResult> AddToCart(AddToCartDto model)
        {
            var response = await _cartService.AddToCart(model);
            return Ok(response);
        }

        [HttpPost]
        [Route("cart/create")]
        public async Task<IActionResult> CreateCart(CreateCartDto cart)
        {
            var response = await _cartService.CreateCart(cart);
            return Ok(response);
        }

        [HttpPut]
        [Route("cart/update")]
        public async Task<IActionResult> UpdateCart(UpdateCartDto cart)
        {
            var response = await _cartService.UpdateCart(cart);
            return Ok(response);
        }

        [HttpDelete]
        [Route("cart/delete/{cartId}")]
        public async Task<IActionResult> DeleteCart(int cartId)
        {
            var response = await _cartService.DeleteCart(cartId);
            return Ok(response);
        }

        [HttpDelete]
        [Route("cart/delete/user/{userId}")]
        public async Task<IActionResult> DeleteCartByUserId(int userId)
        {
            var response = await _cartService.DeleteCartByUserId(userId);
            return Ok(response);
        }

    }
}
