using BrainboxApi.Data;
using BrainboxApi.Entity;
using BrainboxApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BrainboxApi.Repository.Implementations
{
    public class CartRepository : ICartRepository
    {
        private readonly BrainboxDbContext _context;

        public CartRepository(BrainboxDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCart(Cart cart)
        {
            _context.Carts.Add(cart);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateCart(Cart cart)
        {
            _context.Carts.Update(cart);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCart(int cartId)
        {
            var cart = await _context.Carts.FindAsync(cartId);
            _context.Carts.Remove(cart);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCartByUserId(int userId)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(u => u.UserId == userId);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<Cart> GetCartByUserId(int userId)
        {
            return await _context.Carts.Include(c => c.Products).ThenInclude(p => p.Id).FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<Cart> AddToCart(int productId, int quantity, int userId)
        {
            var products = await _context.Products.FindAsync(productId);
            if (products == null)
            {
                return null;
            }

            var cart = await _context.Carts.Include(c => c.Products).FirstOrDefaultAsync(u => u.UserId == userId);
            if (cart == null)
            {
                return null;
            }
            else
            {
                cart.Products.Add(products);
                cart.Quantity += quantity;
                await _context.SaveChangesAsync();
                return cart;
            }         
        }

    }
}
