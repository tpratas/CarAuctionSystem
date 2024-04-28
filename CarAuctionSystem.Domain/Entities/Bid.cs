using CarAuctionSystem.Domain.Common;

namespace CarAuctionSystem.Domain.Entities;

public sealed class Bid : BaseAuditableEntity
{
    public decimal Amount { get; set; }
    public AuctionUser User { get; }

}