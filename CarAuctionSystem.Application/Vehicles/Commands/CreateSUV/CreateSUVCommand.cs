using CarAuctionSystem.Application.Vehicles.Commands.Common;
using CarAuctionSystem.Domain.Entities.Vehicles;
using ErrorOr;
using MediatR;

namespace CarAuctionSystem.Application.Vehicles.Commands.CreateSUV;

public record CreateSUVCommand : BaseCreateVehicleCommand, IRequest<ErrorOr<Guid>>
{
    public int NumberOfSeats { get; set; }
}