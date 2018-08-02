using Microsoft.Extensions.Logging;
using Orleans.Heterogeneous.Interfaces;
using Orleans.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orleans.Heterogeneous.Server2f
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
                .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(Sample2Grain).Assembly).WithReferences())
                .Build())
            {
                await host.StartAsync();

                Console.WriteLine("Silo started. Press any key to terminate...");
                Console.ReadKey();
            }
        }


    }

    public class Sample2Grain : Grain, ISample2
    {
        public Task<string> Ping(string message)
        {
            Console.WriteLine($"Sample2.Pinged with '{message}'");
            return Task.FromResult($"Message '{message}' received");
        }
    }
}
