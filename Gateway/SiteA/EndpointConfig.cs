namespace SiteA
{
    using System.Diagnostics;
    using NServiceBus;
    using NServiceBus.Features;

    // The endpoint is started with the RunGateway profile which turns it on. The Lite profile is also
    // active which will configure the persistence to be InMemory
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.FileShareDataBus(".\\databus");
            // For production use, please select a durable persistence.
            // To use RavenDB, install-package NServiceBus.RavenDB and then use configuration.UsePersistence<RavenDBPersistence>();
            // To use SQLServer, install-package NServiceBus.NHibernate and then use configuration.UsePersistence<NHibernatePersistence>();
            if (Debugger.IsAttached)
            {
                configuration.UsePersistence<InMemoryPersistence>();
            }
            configuration.EnableFeature<Gateway>();
        }
    }
}
