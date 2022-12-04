using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineCakeShop.Models
{
    public class CustomCake
    {
        public int CustomCakeId { get; protected set; }
        public bool Chocolate { get; set; }
        public bool Peanuts { get; set; }
        public bool Apples { get; set; }
        public bool Raspberries { get; set; }
        public bool WhippedCream { get; set; }
        public bool Snickers { get; set; }
        public bool Coconut { get; set; }
        public bool Cookies { get; set; }
        public bool Cherry { get; set; }
        public bool Strawberries { get; set; }
        public bool Vanilla { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "The price cannot be negative")]
        public float Price { get; set; }
        //public virtual ICollection<Quantity>? Quantities { get; set; }
    }
}
