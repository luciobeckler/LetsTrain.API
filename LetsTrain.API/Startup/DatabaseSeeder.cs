using LetsTrain.API.Models.Identity;
using Microsoft.AspNetCore.Identity;

public static class DatabaseSeeder
{
    public static async Task SeedRolesAndAdmin(IServiceProvider services)
    {
        var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

        var roles = new[] { "Admin", "Professor", "Aluno" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new ApplicationRole(role));
        }

        var adminEmail = "admin@teste.com";
        var admin = await userManager.FindByEmailAsync(adminEmail);
        if (admin == null)
        {
            var newAdmin = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
            };

            var result = await userManager.CreateAsync(newAdmin, "SenhaForte123!");
            if (result.Succeeded)
                await userManager.AddToRoleAsync(newAdmin, "Admin");
        }
    }
}
