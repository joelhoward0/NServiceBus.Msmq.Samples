using System;
using NServiceBus;

public class Handler : IHandleMessages<CreateProductCommand>
{
    public void Handle(CreateProductCommand createProductCommand)
    {
        Console.WriteLine("Received a CreateProductCommand message: " + createProductCommand);
    }
}
