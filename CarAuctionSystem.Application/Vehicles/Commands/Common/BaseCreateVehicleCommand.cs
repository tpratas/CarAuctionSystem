namespace CarAuctionSystem.Application.Vehicles.Commands.Common;

public record BaseCreateVehicleCommand
{
    public string VIN { get; set; }
    public int Year { get; set; }
    public TypeCommand Type { get; set; }
    public ManufacturerCommand Manufacturer { get; set; }
    public ModelCommand Model { get; set; }
    public decimal StartingBid { get; set; }
    public string Notes { get; set; }
    public AuctionUserCommand Owner { get; set; }
}

public record TypeCommand(
    Guid Id,
    string Name);

public record ManufacturerCommand(
    Guid Id,
    string Name);

public record ModelCommand(
    Guid Id,
    string Name);

public record AuctionUserCommand(
    Guid Id,
    string Name);