using System;
using System.Diagnostics;
using MyMessages;
using NServiceBus;

class Program
{

    static void Main()
    {
        var busConfiguration = new BusConfiguration();
        busConfiguration.EndpointName("Sample.RequestResponse.Client");
        busConfiguration.UseSerialization<JsonSerializer>();
        if (Debugger.IsAttached)
        {
            // For production use please select a durable persistence and script installers
            busConfiguration.UsePersistence<InMemoryPersistence>();
            busConfiguration.EnableInstallers();
        }
        using (var bus = Bus.Create(busConfiguration))
        {
            bus.Start();
            Console.WriteLine("Press 'Enter' to send a message.To exit, Ctrl + C");

            while (Console.ReadLine() != null)
            {
                var g = Guid.NewGuid();

                Console.WriteLine("==========================================================================");
                Console.WriteLine("Requesting to get data by id: {0}", g.ToString("N"));

                var message = new RequestDataMessage
                {
                    DataId = g,
                    String = "<node>it's my \"node\" & i like it<node>"
                };
                bus.Send("Samples.DataBus.Server",message);
            }
        }
    }
}
