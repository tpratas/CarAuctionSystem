using FluentValidation;

namespace CarAuctionSystem.Application.Auctions.Commands.StartAuction;

public class StartAuctionCommandValidator : AbstractValidator<StartAuctionCommand>
{
    public StartAuctionCommandValidator()
    {
        RuleFor(v => v.VehicleId).NotEmpty();
    }
}