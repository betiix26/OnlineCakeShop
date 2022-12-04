namespace OnlineCakeShop.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public int? CakeId { get; set; }
        public Cake? Cake { get; set; }
    }
}

