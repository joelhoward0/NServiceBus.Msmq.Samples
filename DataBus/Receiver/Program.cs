using System;
using NServiceBus;

class Program
{
    static string BasePath = "..\\..\\..\\storage";
    static void Main()
    {
        var busConfiguration = new BusConfiguration();
        busConfiguration.EndpointName("Sample.DataBus.Receiver");
        busConfiguration.UseSerialization<JsonSerializer>();
        busConfiguration.FileShareDataBus(BasePath);
        busConfiguration.UsePersistence<InMemoryPersistence>();
        busConfiguration.EnableInstallers();
        var startableBus = Bus.Create(busConfiguration);
        using (startableBus.Start())
        {
            Console.WriteLine("\r\nPress enter key to stop program\r\n");
            Console.Read();
        }
    }
}