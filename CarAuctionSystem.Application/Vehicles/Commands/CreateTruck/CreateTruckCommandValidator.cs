using CarAuctionSystem.Application.Common.Constants;
using CarAuctionSystem.Application.Vehicles.Commands.Common;
using FluentValidation;

namespace CarAuctionSystem.Application.Vehicles.Commands.CreateTruck;

public class CreateTruckCommandValidator : BaseCreateVehicleCommandValidator<CreateTruckCommand>
{
    public CreateTruckCommandValidator()
    {
        RuleFor(v => v.LoadCapacity).NotEmpty();
        RuleFor(v => v.LoadCapacity).GreaterThanOrEqualTo(VehicleConstants.MinDoors);
        RuleFor(v => v.LoadCapacity).LessThanOrEqualTo(VehicleConstants.MaxDoors);
    }
}