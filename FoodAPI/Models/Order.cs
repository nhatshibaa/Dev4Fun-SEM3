using Microsoft.EntityFrameworkCore;

namespace FoodAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public double TotalPrice { get; set; }
        public int TotalQuantity { get; set; }
        public int Status { get; set; }
        public virtual ICollection<Account> AccId { get; set; }=new List<Account>();
        public virtual ICollection<OrderDetail> OrderId { get; set; }= new List<OrderDetail>();
        

    }
}
