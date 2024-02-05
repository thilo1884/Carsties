using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;
using Contracts;

namespace AuctionService.RequestHelpers;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
       CreateMap<Auction, AuctionDto>().IncludeMembers(x => x.Item);
       CreateMap<Item, AuctionDto>();

       //d destination, o option, s source
       // Because we have car properties we need to specify the destination
       CreateMap<CreateAuctionDto, Auction>()
            .ForMember(d => d.Item, o => o.MapFrom(s => s));
       CreateMap<CreateAuctionDto, Item>();

       // AuctionCreated it's the between class used between Contracts and AuctionService
       CreateMap<AuctionDto, AuctionCreated>();

       CreateMap<CreateAuctionDto, AuctionUpdated>();

       CreateMap<Auction, AuctionUpdated>().IncludeMembers(a => a.Item);
       CreateMap<Item, AuctionUpdated>();
    }
}
