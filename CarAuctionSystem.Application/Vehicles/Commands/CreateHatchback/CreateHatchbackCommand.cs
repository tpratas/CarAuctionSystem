using CarAuctionSystem.Application.Vehicles.Commands.Common;
using ErrorOr;
using MediatR;

namespace CarAuctionSystem.Application.Vehicles.Commands.CreateHatchback;

public record CreateHatchbackCommand : BaseCreateVehicleCommand, IRequest<ErrorOr<Guid>>
{
    public int NumberOfDoors { get; set; }
}