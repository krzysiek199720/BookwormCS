using System.Text.Json;
using Bookworm.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bookworm.Data;

public static class Seed
{
    public static async Task SeedUsers(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        if (await userManager.Users.AnyAsync()) return;

        var roles = new List<IdentityRole>
        {
            new() { Name = "User" },
            new() { Name = "Admin" },
        };

        foreach (var role in roles)
        {
            await roleManager.CreateAsync(role);
        }

        var user = new AppUser { Email = "user@user.user", UserName = "user"};
        var admin = new AppUser { Email = "admin@admin.admin", UserName = "admin"};

        await userManager.CreateAsync(user, "user");
        await userManager.AddToRoleAsync(user, "User");
        
        await userManager.CreateAsync(admin, "admin");
        await userManager.AddToRolesAsync(admin, new []{ "Admin", "User"});
    }
}