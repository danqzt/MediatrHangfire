using Hangfire;
using Hangfire.MediatR;
using MediatR;
using Microsoft.Extensions.Hosting;
using Sales;
using Shipping;

namespace Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddSales();
                    services.AddShipping();
                    services.AddMediatR(typeof(Program).Assembly);

                    services.AddHangfire(configuration =>
                    {
                        configuration.UseSqlServerStorage("Server=localhost,1433;Database=OrdersDb;User Id=sa;Password=Password1!");
                        configuration.UseMediatR();
                    });

                    services.AddHangfireServer();
                });
    }
}
