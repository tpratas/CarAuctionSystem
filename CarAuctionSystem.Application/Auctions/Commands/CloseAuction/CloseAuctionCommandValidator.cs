using FluentValidation;

namespace CarAuctionSystem.Application.Auctions.Commands.CloseAuction;

public class CloseAuctionCommandValidator : AbstractValidator<CloseAuctionCommand>
{
    public CloseAuctionCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
    }
}