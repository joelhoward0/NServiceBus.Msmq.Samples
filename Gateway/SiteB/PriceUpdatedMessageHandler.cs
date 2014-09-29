namespace SiteB
{
    using System;
    using Headquarter.Messages;
    using NServiceBus;
    public class PriceUpdatedMessageHandler : IHandleMessages<PriceUpdated>
    {
        public void Handle(PriceUpdated message)
        {
            Console.WriteLine("Price update received");
            Console.WriteLine("DataBusProperty: " + message.SomeLargeString.Value);
        }
    }
}