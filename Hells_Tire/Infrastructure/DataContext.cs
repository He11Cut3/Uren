using Hells_Tire.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hells_Tire.Infrastructure
{
	public class DataContext: IdentityDbContext<AppUser>
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{ }

		public DbSet<HellsTireProduct> HellsTireProducts { get; set; }

		public DbSet<HellsTireCategory > HellsTireCategories { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        // ... остальные настройки контекста

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.User)
                .WithMany(u => u.CartItems)
                .HasForeignKey(ci => ci.UserId);
        }
    }
}
