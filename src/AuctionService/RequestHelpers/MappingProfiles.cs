using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;

namespace AuctionService.RequestHelpers;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
       CreateMap<Auction, AuctionDto>().IncludeMembers(x => x.Item);
       CreateMap<Item, AuctionDto>();

       //d destination, o option, s source
       // Because we have car properties we need to specify the destination
       CreateMap<CreateAuctionDto, Auction>().ForMember(d => d.Item, o => o.MapFrom(s => s));
       CreateMap<CreateAuctionDto, Item>();
    }
}
