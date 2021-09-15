using CurrencyConverter.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Run();
        }

        public static IHost CreateHostBuilder(string[] args)
        {
           var host = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).Build();


            //run seeder

            using (var scope = host.Services.CreateScope())
            {

                var logger = scope.ServiceProvider.GetService<ILogger<Program>>();
                try
                {

                    logger.LogInformation("Seeding the database...");
                    var initializer = scope.ServiceProvider.GetService<RateDbInitializer>();
                    initializer.SeedAsync().Wait();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Failed to seed the database");
                }

            }

            //end seeder run

            return host;

        }
    }
}
