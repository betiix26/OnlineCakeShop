using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace OnlineCakeShop.Models
{
    public class CakeContext : DbContext
    {
        public CakeContext(DbContextOptions<CakeContext> options)
           : base(options)
        { }

        public DbSet<Cake>? Cakes { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<CustomCake>? CustomCakes { get; set; }
        public DbSet<Review>? Reviews { get; set; }
        public DbSet<Cart>? Carts { get; set; }
        public DbSet<Quantity>? Quantities { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<Contact>? Contacts { get; set; }
    }
}
