namespace SiteB
{
    using NServiceBus;
    internal class RunInstallers : INeedInitialization
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.EnableInstallers();
        }
    }
}