using System.ComponentModel.DataAnnotations;

namespace OnlineCakeShop.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public virtual ICollection<Cake>? Cakes { get; set; }

        public virtual ICollection<Quantity>? Quantities{ get; set; }
    }
}
