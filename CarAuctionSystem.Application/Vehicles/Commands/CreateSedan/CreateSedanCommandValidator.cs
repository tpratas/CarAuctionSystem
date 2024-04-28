using CarAuctionSystem.Application.Common.Constants;
using CarAuctionSystem.Application.Vehicles.Commands.Common;
using FluentValidation;

namespace CarAuctionSystem.Application.Vehicles.Commands.CreateSedan;

public class CreateSedanCommandValidator : BaseCreateVehicleCommandValidator<CreateSedanCommand>
{
    public CreateSedanCommandValidator()
    {
        RuleFor(v => v.NumberOfDoors).NotEmpty();
        RuleFor(v => v.NumberOfDoors).GreaterThanOrEqualTo(VehicleConstants.MinDoors);
        RuleFor(v => v.NumberOfDoors).LessThanOrEqualTo(VehicleConstants.MaxDoors);
    }
}