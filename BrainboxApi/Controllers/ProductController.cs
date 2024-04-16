using BrainboxApi.DTOs;
using BrainboxApi.Helpers;
using BrainboxApi.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrainboxApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products")]
        public async Task<ActionResult<APIResponse>> GetAllProducts()
        {
           var result = await _productService.GetAllProducts();
            return Ok(result);
        }

        [HttpGet("products/{id}")]
        public async Task<ActionResult<APIResponse>> GetProductById(int id)
        {
            var result = await _productService.GetProductById(id);
            return Ok(result);
        }

        [HttpPost("add-products")]
        public async Task<ActionResult<APIResponse>> AddProduct([FromBody] AddProductDto model)
        {
            var result = await _productService.AddProduct(model);
            return Ok(result);
        }

        [HttpPut("update-products")]
        public async Task<ActionResult<APIResponse>> UpdateProduct([FromBody] UpdateProductDto model)
        {
            var result = await _productService.UpdateProduct(model);
            return Ok(result);
        }

        [HttpDelete("delete-products/{id}")]
        public async Task<ActionResult<APIResponse>> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);
            return Ok(result);
        }

        [HttpPost("products/search")]
        public async Task<ActionResult<APIResponse>> SearchProducts([FromBody] ProductSearchDto model)
        {
            var result = await _productService.SearchProducts(model);
            return Ok(result);
        }
    }
}
