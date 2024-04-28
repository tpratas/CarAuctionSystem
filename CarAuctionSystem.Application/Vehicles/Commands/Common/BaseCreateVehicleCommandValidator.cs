using CarAuctionSystem.Application.Common.Constants;
using FluentValidation;

namespace CarAuctionSystem.Application.Vehicles.Commands.Common;

public abstract class BaseCreateVehicleCommandValidator<TCommand> 
    : AbstractValidator<TCommand> where TCommand : BaseCreateVehicleCommand
{
    protected BaseCreateVehicleCommandValidator()
    {
        RuleFor(v => v.VIN).NotNull().NotEmpty();
        RuleFor(v => v.Year).NotNull();
        RuleFor(v => v.Year).GreaterThanOrEqualTo(VehicleConstants.MinYear);
        RuleFor(v => v.Year).LessThanOrEqualTo(DateTime.Now.Year);
        RuleFor(v => v.Type).NotNull();
        RuleFor(v => v.Type.Id).NotNull();
        RuleFor(v => v.Manufacturer).NotNull();
        RuleFor(v => v.Manufacturer.Id).NotNull();
        RuleFor(v => v.Model).NotNull();
        RuleFor(v => v.Model.Id).NotNull();
        RuleFor(v => v.StartingBid).NotNull();
        RuleFor(v => v.Year).GreaterThanOrEqualTo(VehicleConstants.MinBid);
        RuleFor(v => v.Owner).NotNull();
        RuleFor(v => v.Owner.Id).NotNull();
    }
}
