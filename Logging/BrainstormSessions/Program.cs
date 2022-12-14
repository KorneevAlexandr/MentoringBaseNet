using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace BrainstormSessions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(config)
                    .WriteTo.Email(
                        fromEmail: "app@example.com",
                        toEmail: "support@example.com",
                        mailServer: "smtp.example.com")
                    .CreateLogger();

                try
                {
                    Log.Information("Application Starting.");
                    CreateHostBuilder(args).Build().Run();
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "The Application failed to start.");
                }
                finally
                {
                    Log.Information("Application closed.");
                    Log.CloseAndFlush();
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
