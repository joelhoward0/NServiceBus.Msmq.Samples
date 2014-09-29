namespace SiteB
{
    using System;
    using System.Diagnostics;
    using NServiceBus;
    using NServiceBus.Features;

    class Program
    {
        static void Main()
        {

            var config = new BusConfiguration();
            // For production use, please select a durable persistence.
            // To use RavenDB, install-package NServiceBus.RavenDB and then use configuration.UsePersistence<RavenDBPersistence>();
            // To use SQLServer, install-package NServiceBus.NHibernate and then use configuration.UsePersistence<NHibernatePersistence>();
            if (Debugger.IsAttached)
            {
                config.UsePersistence<InMemoryPersistence>();
            }
            config.UseTransport<MsmqTransport>();
            config.FileShareDataBus(".\\databus");
            config.EnableFeature<Gateway>();

            var bus = Bus.Create(config);
            bus.Start();

            Console.WriteLine("Waiting for price updates from the headquarter - press any key to exit");

            Console.ReadLine();
        }
    }
}
