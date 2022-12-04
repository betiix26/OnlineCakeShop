using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineCakeShop.Models
{
    public class Cake
    {
        [Key]
        public int CakeId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "The name cannot contain more than 60 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The description is mandatory")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The price cannot be negative")]
        public float Price { get; set; }

        [Required(ErrorMessage = "The picture is mandatory")]
        public string? Image { get; set; }

        [Required(ErrorMessage = "The category is required")]
        public DateTime Date { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
