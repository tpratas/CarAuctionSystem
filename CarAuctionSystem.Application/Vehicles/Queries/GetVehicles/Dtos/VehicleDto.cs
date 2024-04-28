using CarAuctionSystem.Application.Common.Mappings;
using CarAuctionSystem.Domain.Entities.Vehicles;

namespace CarAuctionSystem.Application.Vehicles.Queries.GetVehicles.Dtos;

public class VehicleDto : IMapFrom<Vehicle>
{
    public Guid Id { get; set; }
    public string VIN { get; set; }
    public int Year { get; set; }
    public TypeDto Type { get; set; }
    public ManufacturerDto Manufacturer { get; set; }
    public ModelDto Model { get; set; }
    public decimal StartingBid { get; set; }
    public string Notes { get; set; }
    public AuctionUserDto Owner { get; }
}