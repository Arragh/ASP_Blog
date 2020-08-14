using ASP_Blog.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Blog.Models.Config
{
    public class UsersContext : IdentityDbContext<User>
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            IdentityRole adminRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "admin",
                NormalizedName = "ADMIN"
            };

            User adminUser = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Administrator",
                NormalizedUserName = "ADMINISTRATOR",
                Email = Config.AdminEmail,
                NormalizedEmail = Config.NormalizedAdminEmail,
                PasswordHash = new PasswordHasher<User>().HashPassword(null, "Qwe!23"),
                EmailConfirmed = true,
                SecurityStamp = string.Empty
            };

            builder.Entity<IdentityRole>().HasData(adminRole);

            builder.Entity<User>().HasData(adminUser);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRole.Id,
                UserId = adminUser.Id
            });
        }
    }
}
