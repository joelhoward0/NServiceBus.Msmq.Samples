namespace MyClient
{
    using System;
    using NServiceBus;
    using MyMessages;

    public class ClientEndpoint : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            Console.WriteLine("Press 'Enter' to send a message.To exit, Ctrl + C");

            while (Console.ReadLine() != null)
            {
                SendRequestDataMessage();
            }
        }

        public void Stop()
        {
        }

        private void SendRequestDataMessage()
        {
            var g = Guid.NewGuid();

            Console.WriteLine("==========================================================================");
            Console.WriteLine("Requesting to get data by id: {0}", g.ToString("N"));

            Bus.Send<RequestDataMessage>(m =>
            {
                m.DataId = g;
                m.String = "<node>it's my \"node\" & i like it<node>";
            });
        }
    }
}
