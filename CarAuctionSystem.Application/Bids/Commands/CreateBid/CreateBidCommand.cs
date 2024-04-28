using ErrorOr;
using MediatR;

namespace CarAuctionSystem.Application.Bids.Commands.CreateBid;

public record CreateBidCommand : IRequest<ErrorOr<Guid>>
{
    public Guid AuctionId { get; set; }
    public decimal BidAmount { get; set; }
}