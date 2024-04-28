using CarAuctionSystem.Domain.Common;
using CarAuctionSystem.Domain.Entities.Vehicles;

namespace CarAuctionSystem.Domain.Entities;

public class Auction : BaseAuditableEntity
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Vehicle Item { get; set; }
    public IList<Bid> Bids { get; set; }
}
