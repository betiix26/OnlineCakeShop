using System.ComponentModel.DataAnnotations;

namespace OnlineCakeShop.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public virtual ICollection<Cake>? Cakes { get; set; }
    }
}
