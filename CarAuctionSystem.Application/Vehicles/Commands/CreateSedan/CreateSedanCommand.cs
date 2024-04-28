using CarAuctionSystem.Application.Vehicles.Commands.Common;
using CarAuctionSystem.Domain.Entities.Vehicles;
using ErrorOr;
using MediatR;

namespace CarAuctionSystem.Application.Vehicles.Commands.CreateSedan;

public record CreateSedanCommand : BaseCreateVehicleCommand, IRequest<ErrorOr<Guid>>
{
    public int NumberOfDoors { get; set; }
}