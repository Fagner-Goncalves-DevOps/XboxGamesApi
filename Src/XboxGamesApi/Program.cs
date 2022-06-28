using Core.Entities.Identity;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XboxGamesApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           // CreateHostBuilder(args).Build().Run();

            var host = CreateHostBuilder(args).Build();

            ///implementar melhoria no carga do migration para uma extensão, deixando program mais limpa
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var context = services.GetRequiredService<SqlDbContext>();
                    await context.Database.MigrateAsync();
                    await DbContextSeedData.SeedAsync(context, loggerFactory);

                   // var userManager = services.GetRequiredService<UserManager<AppUser>>();
                   // var identityContext = services.GetRequiredService<AppIdentityDbContext>();
                   // await identityContext.Database.MigrateAsync();
                   // await AppIdentityDbContextSeed.SeedUserAsync(userManager);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError($"An error occurred during migration: {ex.Message}");
                }
            }
            ///
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
