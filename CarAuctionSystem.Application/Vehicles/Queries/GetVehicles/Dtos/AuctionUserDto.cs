using CarAuctionSystem.Application.Common.Mappings;
using CarAuctionSystem.Domain.Entities;

namespace CarAuctionSystem.Application.Vehicles.Queries.GetVehicles.Dtos;

public class AuctionUserDto : IMapFrom<AuctionUser>
{
    public Guid Id { get; set; }
    public int Name { get; set; }
}

