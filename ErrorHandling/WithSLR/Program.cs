using System;
using NServiceBus;

static class Program
{
    static void Main()
    {
        var configuration = new BusConfiguration();
        configuration.EndpointName("Samples.ErrorHandling.WithSLR");
        configuration.UseSerialization<JsonSerializer>();
        configuration.UsePersistence<InMemoryPersistence>();
        configuration.EnableInstallers();
        using (var bus = Bus.Create(configuration))
        {
            bus.Start();
            Console.WriteLine("Press any key to send a message that will throw an exception.");
            Console.WriteLine("To exit, press Ctrl + C");

            while (true)
            {
                Console.ReadLine();
                var m = new MyMessage
                {
                    Id = Guid.NewGuid()
                };
                bus.SendLocal(m);
            }
        }
    }
}