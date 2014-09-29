using System;
using MyMessages;
using NServiceBus;

class DataResponseMessageHandler : IHandleMessages<DataResponseMessage>
{
    public void Handle(DataResponseMessage message)
    {
        Console.WriteLine("Response received with description: {0}", message.String);
    }
}