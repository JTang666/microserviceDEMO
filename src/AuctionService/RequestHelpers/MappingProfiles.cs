using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;
using Contracts;
// using Contracts;

namespace AuctionService.RequestHelpers;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Auction, AuctionDto>().IncludeMembers(x => x.Item);
        CreateMap<Item, AuctionDto>();
        CreateMap<CreateAuctionDto, Auction>()
            .ForMember(d => d.Item, o => o.MapFrom(s => s));
        CreateMap<CreateAuctionDto, Item>();

        // transfer AuctionDto to AuctionCreated(in Contracts project), and send it to RabbitMQ
        CreateMap<AuctionDto, AuctionCreated>();
        CreateMap<Item, AuctionUpdated>();
        CreateMap<Auction, AuctionUpdated>().IncludeMembers(a => a.Item);
    }
}