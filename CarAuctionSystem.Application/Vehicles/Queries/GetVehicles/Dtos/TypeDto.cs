using CarAuctionSystem.Application.Common.Mappings;

namespace CarAuctionSystem.Application.Vehicles.Queries.GetVehicles.Dtos;

public class TypeDto : IMapFrom<Type>
{
    public Guid Id { get; set; }
    public int Name { get; set; }
}

