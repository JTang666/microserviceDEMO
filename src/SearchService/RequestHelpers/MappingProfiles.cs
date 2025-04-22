using System;
using AutoMapper;
using Contracts;
using SearchService.Models;

namespace SearchService.RequestHelpers;

// implementation of the AutoMapper profile
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // transform the AuctionCreated and AuctionUpdated objects to Item object(which will be saved to the database)
        CreateMap<AuctionCreated, Item>();
        CreateMap<AuctionUpdated, Item>();
    }
}