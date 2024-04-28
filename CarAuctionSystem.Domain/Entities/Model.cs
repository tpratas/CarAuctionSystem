using CarAuctionSystem.Domain.Common;

namespace CarAuctionSystem.Domain.Entities;

public sealed class Model : BaseEntity
{
    public string Name { get; set; }
}