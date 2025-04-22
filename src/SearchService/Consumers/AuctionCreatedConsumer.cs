using System;
using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Consumers;

// implementation of the IConsumer interface
// that consumes the AuctionCreated object(which is defined in Contract folder) message
// we save the AuctionCreated object to the database(mongodb)
public class AuctionCreatedConsumer(IMapper mapper) : IConsumer<AuctionCreated>
{
    public async Task Consume(ConsumeContext<AuctionCreated> context)
    {
        Console.WriteLine("--> Consuming Auction Created: " + context.Message.Id);

        var item = mapper.Map<Item>(context.Message);

        if (item.Model == "Foo")
            throw new ArgumentException("Cannot sell cars with name of Foo");

        await item.SaveAsync();
    }
}