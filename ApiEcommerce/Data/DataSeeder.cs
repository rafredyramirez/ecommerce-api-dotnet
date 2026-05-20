using ApiEcommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApiEcommerce.Data
{
    public static class DataSeeder
    {
        public static async Task SeedDataAsync(ApplicationDbContext appContext)
        {
            await SeedRolesAsync(appContext);

            await SeedCategoriesAsync(appContext);

            await SeedUsersAsync(appContext);

            await SeedUserRolesAsync(appContext);

            await SeedProductsAsync(appContext);
        }

        private static async Task SeedRolesAsync(ApplicationDbContext appContext)
        {
            if (await appContext.Roles.AnyAsync())
                return;

            await appContext.Roles.AddRangeAsync(
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "USER"
                }
            );

            await appContext.SaveChangesAsync();
        }

        private static async Task SeedCategoriesAsync(ApplicationDbContext appContext)
        {
            if (await appContext.Categories.AnyAsync())
                return;

            await appContext.Categories.AddRangeAsync(
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Ropa y accesorios",
                    CreationDate = DateTime.UtcNow
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Electrónicos",
                    CreationDate = DateTime.UtcNow
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Deportes",
                    CreationDate = DateTime.UtcNow
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Hogar",
                    CreationDate = DateTime.UtcNow
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Libros",
                    CreationDate = DateTime.UtcNow
                }
            );

            await appContext.SaveChangesAsync();
        }

        private static async Task SeedUsersAsync(ApplicationDbContext appContext)
        {
            if (await appContext.ApplicationUsers.AnyAsync())
                return;

            var hasher = new PasswordHasher<ApplicationUser>();

            var adminUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                Name = "Administrador"
            };

            adminUser.PasswordHash =
                hasher.HashPassword(adminUser, "Admin123!");

            var regularUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user@user.com",
                NormalizedUserName = "USER@USER.COM",
                Email = "user@user.com",
                NormalizedEmail = "USER@USER.COM",
                EmailConfirmed = true,
                Name = "Usuario Regular"
            };

            regularUser.PasswordHash =
                hasher.HashPassword(regularUser, "User123!");

            await appContext.ApplicationUsers.AddRangeAsync(
                adminUser,
                regularUser
            );

            await appContext.SaveChangesAsync();
        }

        private static async Task SeedUserRolesAsync(ApplicationDbContext appContext)
        {
            if (await appContext.UserRoles.AnyAsync())
                return;

            var adminRole = await appContext.Roles
                .FirstAsync(r => r.Name == "Admin");

            var userRole = await appContext.Roles
                .FirstAsync(r => r.Name == "User");

            var adminUser = await appContext.ApplicationUsers
                .FirstAsync(u => u.Email == "admin@admin.com");

            var regularUser = await appContext.ApplicationUsers
                .FirstAsync(u => u.Email == "user@user.com");

            await appContext.UserRoles.AddRangeAsync(
                new IdentityUserRole<string>
                {
                    UserId = adminUser.Id,
                    RoleId = adminRole.Id
                },
                new IdentityUserRole<string>
                {
                    UserId = regularUser.Id,
                    RoleId = userRole.Id
                }
            );

            await appContext.SaveChangesAsync();
        }

        private static async Task SeedProductsAsync(ApplicationDbContext appContext)
        {
            if (await appContext.Products.AnyAsync())
                return;

            var ropaCategory = await appContext.Categories
                .FirstAsync(c => c.Name == "Ropa y accesorios");

            var electronicsCategory = await appContext.Categories
                .FirstAsync(c => c.Name == "Electrónicos");

            var sportsCategory = await appContext.Categories
                .FirstAsync(c => c.Name == "Deportes");

            var homeCategory = await appContext.Categories
                .FirstAsync(c => c.Name == "Hogar");

            var booksCategory = await appContext.Categories
                .FirstAsync(c => c.Name == "Libros");

            await appContext.Products.AddRangeAsync(
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Camiseta Básica",
                    Description = "Camiseta de algodón 100%",
                    Price = 25.99m,
                    Sku = "PROD-001-CAM-M",
                    Stock = 50,
                    CategoryId = ropaCategory.Id,
                    Category = ropaCategory,
                    ImgUrl = "https://via.placeholder.com/300x300/FF0000/FFFFFF?text=Camiseta",
                    CreationDate = DateTime.UtcNow
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Smartphone Galaxy",
                    Description = "Teléfono inteligente con 128GB",
                    Price = 599.99m,
                    Sku = "PROD-002-PHO-BLK",
                    Stock = 25,
                    CategoryId = electronicsCategory.Id,
                    Category = ropaCategory,
                    ImgUrl = "https://via.placeholder.com/300x300/0000FF/FFFFFF?text=Smartphone",
                    CreationDate = DateTime.UtcNow
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Pelota de Fútbol",
                    Description = "Pelota oficial FIFA",
                    Price = 45.00m,
                    Sku = "PROD-003-BAL-WHT",
                    Stock = 30,
                    CategoryId = sportsCategory.Id,
                    Category = ropaCategory,
                    ImgUrl = "https://via.placeholder.com/300x300/00FF00/FFFFFF?text=Pelota",
                    CreationDate = DateTime.UtcNow
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Lámpara de Mesa",
                    Description = "Lámpara LED regulable",
                    Price = 89.99m,
                    Sku = "PROD-004-LAM-WHT",
                    Stock = 15,
                    CategoryId = homeCategory.Id,
                    Category = ropaCategory,
                    ImgUrl = "https://via.placeholder.com/300x300/FFFF00/000000?text=Lampara",
                    CreationDate = DateTime.UtcNow
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    Name = "El Quijote",
                    Description = "Novela clásica de Cervantes",
                    Price = 19.99m,
                    Sku = "PROD-005-LIB-ESP",
                    Stock = 100,
                    CategoryId = booksCategory.Id,
                    Category = ropaCategory,
                    ImgUrl = "https://via.placeholder.com/300x300/800080/FFFFFF?text=Libro",
                    CreationDate = DateTime.UtcNow
                }
            );

            await appContext.SaveChangesAsync();
        }
    }
}
