namespace MyServer
{
    using MyMessages;
    using NServiceBus;
    using System;

    public class RequestDataMessageHandler : IHandleMessages<RequestDataMessage>
    {
        public IBus Bus { get; set; }

        public void Handle(RequestDataMessage message)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine("Received request {0}.", message.DataId);
            Console.WriteLine("String received: {0}.", message.String);
           
            var response = new DataResponseMessage
            { 
                DataId = message.DataId,
                String = message.String
            };
            
            Bus.Reply(response); //Try experimenting with sending multiple responses
        }
    }
}
