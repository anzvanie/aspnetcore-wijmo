using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ASPNetCore_Wijmo.Models;

namespace ASPNetCore_Wijmo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            var services = host.Services;

            try
            {
                var context = services.GetRequiredService<ASPNetCore_WijmoContext>();
                context.Database.Migrate();
                SeedData.Initialize(services);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(new EventId(0x0001, "Program start"), ex, "An error occurred seeding the DB.");
            }

            host.Run();
        }
    }
}
