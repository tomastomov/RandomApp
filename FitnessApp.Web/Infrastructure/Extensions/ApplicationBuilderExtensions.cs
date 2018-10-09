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
                    var adminName = GlobalConstants.AdministratorRole;
                    
                    var exists = await roleManager.RoleExistsAsync(adminName);

                    if (!exists)
                    {
                        await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = adminName
                        });
                    }

                    var adminUser = await userManager.FindByNameAsync(adminName);


                    if (adminUser == null)
                    {
                        adminUser = new User
                        {
                            UserName = "admin",
                            Name = adminName,
                            Email = "admin@admin.com",
                            SecurityStamp = "S0M3RAND0MVALU3"
                        };
                        
                        await userManager.CreateAsync(adminUser, "admin12");
                        await userManager.AddToRoleAsync(adminUser, adminName);
                    }

                })
                .GetAwaiter()
                .GetResult();
            }

        }
        
    }
}
