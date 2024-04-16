namespace BrainboxApi.Entity
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
