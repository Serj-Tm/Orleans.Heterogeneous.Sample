using Microsoft.Extensions.Logging;
using Orleans.Heterogeneous.Interfaces;
using Orleans.Hosting;
using System;
using System.Threading.Tasks;

namespace Orleans.Heterogeneous.Server1c
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await StartSilo();
        }
        static async Task StartSilo()
        {
            using (var host = new SiloHostBuilder()
                .UseLocalhostClustering()
                .ConfigureLogging(logging => logging.AddConsole())
                .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(ISample2).Assembly).WithReferences())
                .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(Sample1Grain).Assembly).WithReferences())
                .Build())
            {
                await host.StartAsync();

                Console.WriteLine("Silo started. Press any key to terminate...");
                Console.ReadKey();
            }
        }


    }

    public class Sample1Grain : Grain, ISample1
    {
        public Task<string> Ping(string message)
        {
            Console.WriteLine($"Sample1. Pinged with '{message}'");
            return Task.FromResult($"Message '{message}' received");
        }
    }
}
