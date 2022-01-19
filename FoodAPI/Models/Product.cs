namespace FoodAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public string Vote { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
        public DateTime Timestamp { get; set; }

        public virtual ICollection<Category> CategoriesId { get; set; } = new List<Category>();
    }
}
