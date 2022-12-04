namespace OnlineCakeShop.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public virtual ICollection<Quantity>? Quantities { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}


