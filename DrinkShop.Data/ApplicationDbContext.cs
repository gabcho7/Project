
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

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder
            //     .Entity<User>()
            //     .HasIndex(u => u.Id)
            //     .IsUnique();

            //builder
            //    .Entity<Order>()
            //    .HasOne(o => o.User)
            //    .WithMany(u => u.Orders)
            //    .HasForeignKey(o => o.UserId);


            //builder
            //    .Entity<OrderDetail>()
            //    .HasOne(od => od.Order)
            //    .WithMany(o => o.OrderDetails)
            //    .HasForeignKey(od => od.OrderId);

            //builder
            //    .Entity<OrderDetail>()
            //    .HasOne(od => od.Drink)
            //    .WithMany(o => o.OrderDetails)
            //    .HasForeignKey(od => od.DrinkId);

            //builder
            //   .Entity<Drink>()
            //   .HasOne(d => d.Category)
            //   .WithMany(c => c.Drinks)
            //   .HasForeignKey(od => od.DrinkId);

            //builder
            //   .Entity<ShoppingCart>()
            //   .HasOne(c => c.User)
            //   .WithOne(u => u.Cart)
            //   .HasForeignKey<ShoppingCart>(c => c.UserId)
            //   ;
            //builder
            //   .Entity<User>()
            //   .HasOne(c => c.Cart)
            //   .WithOne(u => u.User)
            //   .HasForeignKey<User>(u => u.CartId);


            builder
                .Entity<Drink>()
                .HasOne(d => d.Category)
                .WithMany(c => c.Drinks)
                .HasForeignKey(d => d.CategoryId);


            builder
                .Entity<CartItem>()
                .HasOne(ci => ci.ShoppingCart)
                .WithMany(sc => sc.CartItems);
               

            builder
                .Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            builder
                .Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            base.OnModelCreating(builder);
           
        }
    }
}
