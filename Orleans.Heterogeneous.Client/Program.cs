using Orleans.Heterogeneous.Interfaces;
using System;
using System.Threading.Tasks;

namespace Orleans.Heterogeneous.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await PingSample();
        }

        static async Task PingSample()
        {
            using (var client = new ClientBuilder()
                .UseLocalhostClustering()
                //.ConfigureLogging(logging => logging.AddConsole())
                .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(ISample1).Assembly).WithReferences())
                .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(ISample2).Assembly).WithReferences())
                .Build())
            {
                await client.Connect();
                Console.WriteLine("Client successfully connected to silo host.");

                if (true)
                {
                    var sample = client.GetGrain<ISample2>("one");

                    var result = await sample.Ping("hello2");
                    Console.WriteLine(result);
                }
                if (true)
                {
                    var sample = client.GetGrain<ISample1>("one");

                    var result = await sample.Ping("hello1");
                    Console.WriteLine(result);
                }
            }

        }
    }
}
