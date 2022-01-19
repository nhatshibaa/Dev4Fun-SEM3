namespace FoodAPI.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int ListProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
