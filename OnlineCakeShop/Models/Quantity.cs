namespace OnlineCakeShop.Models
{
    public class Quantity
    {
        public int QuantityId { get; set; }
        public int TotalAmount { get; set; }
        public int? CakeId { get; set; }
        public Cake? Cake { get; set; }
        public int? CustomCakeId { get; set; }
        public CustomCake? CustomCake { get; set; }

    }
}
