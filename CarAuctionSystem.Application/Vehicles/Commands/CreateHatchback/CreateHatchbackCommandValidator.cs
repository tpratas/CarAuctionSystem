using CarAuctionSystem.Application.Common.Constants;
using CarAuctionSystem.Application.Vehicles.Commands.Common;
using FluentValidation;

namespace CarAuctionSystem.Application.Vehicles.Commands.CreateHatchback;

public class CreateHatchbackCommandValidator : BaseCreateVehicleCommandValidator<CreateHatchbackCommand>
{
    public CreateHatchbackCommandValidator()
    {
        RuleFor(v => v.NumberOfDoors).NotEmpty();
        RuleFor(v => v.NumberOfDoors).GreaterThanOrEqualTo(VehicleConstants.MinDoors);
        RuleFor(v => v.NumberOfDoors).LessThanOrEqualTo(VehicleConstants.MaxDoors);
    }
}