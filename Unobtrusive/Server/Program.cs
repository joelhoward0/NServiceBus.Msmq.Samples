using System;
using NServiceBus;

class Program
{
    public static void Main()
    {
        var busConfiguration = new BusConfiguration();

        busConfiguration.EnableInstallers();
        busConfiguration.UsePersistence<InMemoryPersistence>();
        busConfiguration.UseDataBus<FileShareDataBus>()
            .BasePath(@"..\..\..\DataBusShare\");
        busConfiguration.RijndaelEncryptionService();

        var conventions = busConfiguration.Conventions();
        conventions.DefiningCommandsAs(t => t.Namespace != null && t.Namespace.EndsWith("Commands"));
        conventions.DefiningEventsAs(t => t.Namespace != null && t.Namespace.EndsWith("Events"));
        conventions.DefiningMessagesAs(t => t.Namespace == "Messages");
        conventions.DefiningEncryptedPropertiesAs(p => p.Name.StartsWith("Encrypted"));
        conventions.DefiningDataBusPropertiesAs(p => p.Name.EndsWith("DataBus"));
        conventions.DefiningExpressMessagesAs(t => t.Name.EndsWith("Express"));
        conventions
            .DefiningTimeToBeReceivedAs(t => t.Name.EndsWith("Expires")
                ? TimeSpan.FromSeconds(30)
                : TimeSpan.MaxValue
            );

        var bus = Bus.Create(busConfiguration);
        bus.Start();
        CommandSender.Start(bus);
    }
}

