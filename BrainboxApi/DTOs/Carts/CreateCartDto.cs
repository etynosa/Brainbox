using BrainboxApi.Entity;

namespace BrainboxApi.DTOs.Carts
{
    public class CreateCartDto
    {
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
