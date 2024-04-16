using BrainboxApi.DTOs;
using BrainboxApi.Entity;

namespace BrainboxApi.Repository.IRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<int> AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
        Task<List<Product>> SearchProducts(ProductSearchDto model);
    }
}
