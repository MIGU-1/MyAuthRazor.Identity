using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAuthRazor.Identity
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetService<UserManager<IdentityUser>>();
                var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                if (!userManager.Users.Any())
                {
                    await roleManager.CreateAsync(new IdentityRole("User"));
                    await roleManager.CreateAsync(new IdentityRole("Admin"));

                    var admin = new IdentityUser { UserName = "MIGU", Email = "migu@test.at" };
                    var user = new IdentityUser { UserName = "SIAI", Email = "siai@test.at" };

                    await userManager.CreateAsync(admin, "Test#123");
                    await userManager.CreateAsync(user, "Test#123");

                    await userManager.AddToRoleAsync(user, "User");
                    await userManager.AddToRolesAsync(admin, new[] { "User", "Admin" });
                }

                host.Run();
            }


        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
