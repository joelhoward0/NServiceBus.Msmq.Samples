using System;
using System.Diagnostics;
using NServiceBus;

class Program
{

    static void Main()
    {
        var busConfiguration = new BusConfiguration();
        busConfiguration.EndpointName("Samples.DataBus.Server");
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
            Console.WriteLine("To exit, Ctrl + C");

            Console.ReadLine();
        }
    }
}