using CarAuctionSystem.Domain.Common;

namespace CarAuctionSystem.Domain.Entities;

public sealed class Manufacturer : BaseEntity
{
    public string Name { get; set; }
}