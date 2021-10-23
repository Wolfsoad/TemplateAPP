using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using STRACT.Identity.Entities;
using STRACT.Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STRACT.Data;
using ElectronNET.API;

namespace STRACT.web
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    //#region SQL Server Seed
                    //var context = services.GetRequiredService<ApplicationDbContext>();
                    //var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    //var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    //await ContextSeed.SeedRolesAsync(userManager, roleManager);
                    //await ContextSeed.SeedSuperAdminAsync(userManager, roleManager);
                    //await ContextSeed.SeedBasicUserAsync(userManager, roleManager);
                    //await PDCContextSeed.SeedDatabase(context);
                    //#endregion

                    #region SQLite Seed
                    var context = services.GetRequiredService<PDCContext>();
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await ContextSeed.SeedRolesAsync(userManager, roleManager);
                    await ContextSeed.SeedSuperAdminAsync(userManager, roleManager);
                    await ContextSeed.SeedBasicUserAsync(userManager, roleManager);
                    await PDCContextSeed.SeedDatabase(context);
                    #endregion

                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseElectron(args);
                    webBuilder.UseStartup<Startup>();
                });
    }
}
