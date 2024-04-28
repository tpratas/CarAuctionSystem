using CarAuctionSystem.Application.Vehicles.Commands.Common;
using ErrorOr;
using MediatR;

namespace CarAuctionSystem.Application.Vehicles.Commands.CreateTruck;

public record CreateTruckCommand : BaseCreateVehicleCommand, IRequest<ErrorOr<Guid>>
{
    public int LoadCapacity { get; set; }
}