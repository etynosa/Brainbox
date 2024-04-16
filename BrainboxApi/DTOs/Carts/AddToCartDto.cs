namespace BrainboxApi.DTOs.Carts
{
    public class AddToCartDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
    }
}
