using ErrorOr;
using MediatR;

namespace CarAuctionSystem.Application.Auctions.Commands.CloseAuction;

public record CloseAuctionCommand : IRequest<ErrorOr<Guid>>
{
    public Guid Id { get; set; }
}