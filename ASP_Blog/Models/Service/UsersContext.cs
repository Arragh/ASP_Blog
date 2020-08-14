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

        // Создаем начального пользователя Administrator с правами admin
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Создаем роль администратора
            IdentityRole adminRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "admin",
                NormalizedName = "ADMIN"
            };

            // Создаем пользователя Администратора
            User adminUser = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = Config.AdminName,
                NormalizedUserName = Config.NormalizedAdminName,
                Email = Config.AdminEmail,
                NormalizedEmail = Config.NormalizedAdminEmail,
                PasswordHash = new PasswordHasher<User>().HashPassword(null, Config.AdminPassword),
                EmailConfirmed = true,
                SecurityStamp = string.Empty
            };

            // Заносим роль в БД
            builder.Entity<IdentityRole>().HasData(adminRole);

            // Заносим пользователя в БД
            builder.Entity<User>().HasData(adminUser);

            // Пользователю Administrator присваиваем роль admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRole.Id,
                UserId = adminUser.Id
            });
        }
    }
}
