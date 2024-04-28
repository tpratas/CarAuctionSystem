using CarAuctionSystem.Domain.Common;

namespace CarAuctionSystem.Domain.Entities;

public sealed class AuctionUser: BaseAuditableEntity
{
    public string Name { get; set; } = string.Empty;
}