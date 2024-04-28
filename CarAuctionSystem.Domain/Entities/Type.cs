using CarAuctionSystem.Domain.Common;

namespace CarAuctionSystem.Domain.Entities;

public sealed class Type : BaseEntity
{
    public string Name { get; set; }
}