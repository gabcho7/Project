
namespace DrinkShop.Data
{
    using DrinkShop.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
   
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public DbSet<Drink> Drinks { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
                .Entity<Drink>()
                .HasOne(d => d.Category)
                .WithMany(c => c.Drinks)
                .HasForeignKey(d => d.CategoryId);

            builder
                .Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            builder
                .Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(i => i.Order)
                .HasForeignKey(i => i.OrderId);



            base.OnModelCreating(builder);
           
        }
    }
}
