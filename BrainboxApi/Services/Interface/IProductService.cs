using BrainboxApi.DTOs;
using BrainboxApi.Helpers;

namespace BrainboxApi.Services.Interface
{
    public interface IProductService
    {
        Task<APIResponse> GetAllProducts();
        Task<APIResponse> GetProductById(int id);
        Task<APIResponse> AddProduct(AddProductDto model);
        Task<APIResponse> UpdateProduct(UpdateProductDto model);
        Task<APIResponse> DeleteProduct(int id);
        Task<APIResponse> SearchProducts(ProductSearchDto model);
    }
}
