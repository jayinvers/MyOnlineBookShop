using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyOnlineShop.Models;

namespace MyOnlineShop.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions<DataContext> options)
    : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("users");

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "New Arrival" },
                new Category { CategoryId = 2, Name = "Best Choice" }
                );

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, CategoryId = 1, ISBN = "9780451495204", Price = 28.99M, Title = "Mercury Pictures Presents", Created = DateTime.Now, Picture = "https://pub.booklistonline.com/Content/Images/userupload/7/77/771/771d742ab4ee40098075ce28fb7d3084.jpg" },
                new Book { BookId = 2, CategoryId = 1, ISBN = "9780763698225", Price = 24.99M, Title = "The Assassination of Brangwain Spurge", Created = DateTime.Now, Picture = "https://images-na.ssl-images-amazon.com/images/I/519W0nbxbZL.jpg" }
                );

//            SeedUserAndRoles(modelBuilder);

        }


        private void SeedUserAndRoles(ModelBuilder builder)
        {
           
            string userGuid = Guid.NewGuid().ToString();
            string adminRoleGuid = Guid.NewGuid().ToString();
            string userRoleGuid = Guid.NewGuid().ToString();
            IdentityUser user = new IdentityUser()
            {
                Id = userGuid,
                UserName = "admin",
                Email = "maxazure@gmail.com",
                LockoutEnabled = false,
                PhoneNumber = "1234567890"
            };

            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "admin123");


            builder.Entity<IdentityUser>().HasData(user);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = adminRoleGuid, Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = userRoleGuid, Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
                );

            builder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string>() { RoleId = adminRoleGuid, UserId = userGuid }
                    );
        }
    }
}
