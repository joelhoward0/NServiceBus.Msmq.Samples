using NServiceBus;

public static class BusConfigExtensions
{
    public static void RegisterMessageEncryptor(this BusConfiguration busConfiguration)
    {
        busConfiguration.RegisterComponents(c => c.ConfigureComponent<MessageEncryptor>(DependencyLifecycle.InstancePerCall));
    }
}