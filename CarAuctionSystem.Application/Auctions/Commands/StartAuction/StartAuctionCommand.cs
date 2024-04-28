using ErrorOr;
using MediatR;

namespace CarAuctionSystem.Application.Auctions.Commands.StartAuction;

public record StartAuctionCommand : IRequest<ErrorOr<Guid>>
{
    public Guid VehicleId { get; set; }
}