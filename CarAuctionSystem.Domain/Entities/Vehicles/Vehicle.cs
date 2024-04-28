using CarAuctionSystem.Domain.Common;

namespace CarAuctionSystem.Domain.Entities.Vehicles;

public class Vehicle : BaseAuditableEntity
{
    public string VIN { get; set; }
    public int Year { get; set; }
    public Type Type { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public Model Model { get; set; }
    public decimal StartingBid { get; set; }
    public string Notes { get; set; }
    public AuctionUser Owner { get; }
}