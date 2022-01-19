namespace FoodAPI.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
        public int VoteStar { get; set; }
        public int Status { get; set; }
        public virtual ICollection<Account> AccEmail { get; set; }=new List<Account>();
    }
}
