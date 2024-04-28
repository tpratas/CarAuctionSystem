using FluentValidation;

namespace CarAuctionSystem.Application.Bids.Commands.CreateBid;

public class CreateBidCommandValidator : AbstractValidator<CreateBidCommand>
{
    public CreateBidCommandValidator()
    {
        RuleFor(v => v.AuctionId).NotEmpty();
        RuleFor(v => v.BidAmount).NotEmpty();
    }
}