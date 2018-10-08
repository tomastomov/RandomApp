namespace FitnessApp.Web.Infrastructure.Extensions
{
    using Data.Data;
    using Data.Models;
    using Common.Contants;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtensions
    {
        public static void UpdateDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<FitnessAppDbContext>();
                context.Database.Migrate();

                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();

                Task.Run(async () =>
                {
                    var adminName = GlobalConstants.Administrator;

                    await CreateRole(roleManager, adminName);

                    var adminUser = await userManager.FindByNameAsync(adminName);

                    if (adminUser == null)
                    {
                        adminUser = new User
                        {
                            UserName = "admin",
                            Email = "admin@admin.com"
                        };

                        await userManager.CreateAsync(adminUser, "admin12");
                        await userManager.AddToRoleAsync(adminUser, adminName);
                    }

                })
                .GetAwaiter()
                .GetResult();
            }

        }
        private async static Task CreateRole(RoleManager<IdentityRole> roleManager, string roleName)
        {
            var roleNameExists = await roleManager.RoleExistsAsync(roleName);

            if (!roleNameExists)
            {
                await roleManager.CreateAsync(new IdentityRole { Name = roleName });
            }

            return;
        }
    }
}
