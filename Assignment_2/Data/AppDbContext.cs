using Microsoft.EntityFrameworkCore;
using Assignment_3.Models;
namespace Assignment_3.Data
{
    public class AppDbContext : DbContext
    {
       public DbSet<User> Users { get; set; }
       public DbSet<Product> Products { get; set; }

        public AppDbContext (DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Name).IsRequired().HasMaxLength(50);

            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.CreatedAt).HasDefaultValueSql("GETDATE()");
                entity.Property(t => t.Price);

                entity.HasOne(t => t.User).WithMany(u => u.Product).HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.Cascade);

            });

            base.OnModelCreating(modelBuilder);


        }
    }
}
