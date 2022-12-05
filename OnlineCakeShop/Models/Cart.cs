using System.ComponentModel.DataAnnotations;

namespace OnlineCakeShop.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public int? QuantityId { get; set; }
        public Quantity? Quantity { get; set; }
        public virtual ICollection<Cake>? Cakes { get; set; }
    }
}
