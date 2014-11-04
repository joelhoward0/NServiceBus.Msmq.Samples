using NServiceBus;

class Program
{
    public static void Main()
    {
        var busConfiguration = new BusConfiguration();
        busConfiguration.UsePersistence<InMemoryPersistence>();

        busConfiguration.RegisterComponents(components =>
        {
            components.ConfigureComponent<ValidationMessageMutator>(DependencyLifecycle.InstancePerCall);
            components.ConfigureComponent<TransportMessageCompressionMutator>(DependencyLifecycle.InstancePerCall);
        });
        using (var bus = Bus.Create(busConfiguration))
        {
            bus.Start();
            Runner.Run(bus);
        }
    }
}