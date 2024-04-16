using BrainboxApi.Data;
using BrainboxApi.DTOs;
using BrainboxApi.Entity;
using BrainboxApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;

namespace BrainboxApi.Repository.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly BrainboxDbContext _context;

        public ProductRepository(BrainboxDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<int> AddProduct(Product product)
        {
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public Task<List<Product>> SearchProducts(ProductSearchDto model)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(model.Query))
            {
                query = query.Where(p => p.Name.Contains(model.Query) || p.Description.Contains(model.Query));
            }

            if (!string.IsNullOrEmpty(model.Category))
            {
                query = query.Where(p => p.Category == model.Category);
            }

            return query.ToListAsync();
        }
    }
}
