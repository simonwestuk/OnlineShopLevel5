using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop2022.Models;

namespace OnlineShop2022.Data
{
    public class AppDbContext : IdentityDbContext<CustomUserModel>
    {
        public DbSet<ProductModel> Products { get; set; }

        public DbSet<OnlineShop2022.Models.CategoryModel> CategoryModel { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedAdmin(builder);
            this.SeedRoles(builder);
            this.SeedUserRoles(builder);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = "78bf8cbe-1f70-4d6d-890b-247bc57e6150",
                    Name = "Admin",
                    NormalizedName = "Admin",
                    ConcurrencyStamp =  "1"

                }
                );
        }


        private void SeedAdmin(ModelBuilder builder)
        {

            CustomUserModel user = new CustomUserModel();
            user.Id = "27b9af34-a133-43e2-8dd2-aef04ddb2b8c";
            user.UserName = "admin@admin.com";
            user.NormalizedUserName = "admin@admin.com";
            user.NormalizedEmail = "admin@admin.com";
            user.Email = "admin@admin.com";
            user.LockoutEnabled = false;
            user.Fname = "Admin";
            user.Sname = "Admin";
            user.ConcurrencyStamp = "1";

            PasswordHasher hasher = new PasswordHasher();
            var password = hasher.HashPassword("Admin123!");
            user.PasswordHash = password;

            builder.Entity<CustomUserModel>().HasData(user);

        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string>()
                {
                    RoleId = "78bf8cbe-1f70-4d6d-890b-247bc57e6150",
                    UserId = "27b9af34-a133-43e2-8dd2-aef04ddb2b8c"
                });

        }
    }
}
